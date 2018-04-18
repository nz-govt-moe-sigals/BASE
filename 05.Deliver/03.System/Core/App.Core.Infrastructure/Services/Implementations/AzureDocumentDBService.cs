using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// requires nuget: Microsoft.Azure.DocumentDB


namespace App.Core.Infrastructure.Services.Implementations
{
    using System.Collections.ObjectModel;
    using System.Reflection;
    using App.Core.Infrastructure.Services.Configuration.Implementations;
    using Microsoft.Azure.Documents;
    using Microsoft.Azure.Documents.Client;
    using Microsoft.Azure.Documents.Linq;
    using Newtonsoft.Json;

    public class AzureDocumentDBService : IAzureDocumentDBService
    {

        private DocumentDbServiceConfiguration _configuration;
        private DocumentClient _documentClient;
        private IDiagnosticsTracingService _diagnosticsTracingService;

        public DocumentDbServiceConfiguration Configuration
        {
            get
            {
                return _configuration;
            }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentDBService"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="diagnosticsTracingService">The diagnostics tracing service.</param>
        public AzureDocumentDBService(DocumentDbServiceConfiguration configuration,
            IDiagnosticsTracingService diagnosticsTracingService)
        {
            this._configuration = configuration;
            _diagnosticsTracingService = diagnosticsTracingService;

            this._documentClient = CreateClient(this._configuration.EndpointUrl, this._configuration.AuthorizationKey);
        }

        private DocumentClient CreateClient(Uri endpointUrl, string authorizationKey)
        {
            return new DocumentClient(endpointUrl, authorizationKey);
        }

        private DocumentClient CreateClient(Uri endpointUrl, string authorizationKey, JsonSerializerSettings jsonSerializerSettings)
        {
            return new DocumentClient(endpointUrl, authorizationKey, jsonSerializerSettings);
        }


        private IQueryable<TDocument> CreateDocumentQuery<TDocument>(Uri collectionLinkUri, SqlQuerySpec sqlQuerySpec)
        {
            return this._documentClient.CreateDocumentQuery<TDocument>(collectionLinkUri, sqlQuerySpec);
        }



        private static string GetDocumentIdByReflection<TDocument>(TDocument document)
        {
            var propertyInfo = document.GetType().GetProperty("Id",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
            if (propertyInfo == null)
            {
                throw new Exception("If documentUri is not provided, Document itself must implement IHasId");
            }
            string documentId = propertyInfo.GetValue(document, null).ToString();
            return documentId;
        }


        /// <summary>
        /// Gets the database ids.
        /// </summary>
        /// <returns></returns>
        public async Task<string[]> GetDatabaseIds()
        {
            return this._documentClient.CreateDatabaseQuery().Select(x => x.Id).ToArray();
        }

        public void CreateDatabase(string databaseId, bool throwExceptionIfAlreadyExisting = true)
        {
            CreateDatabaseAsync(databaseId, throwExceptionIfAlreadyExisting)
                .Wait(this._configuration.TimeoutMilliseconds);
        }



        /// <summary>
        /// Creates the defined database if it does not already exist.
        /// </summary>
        /// <param name="databaseId">The database identifier.</param>
        /// <param name="throwExceptionIfAlreadyExisting">if set to <c>true</c>, throws an exception if the database already existing.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Database already exists.</exception>
        public async Task CreateDatabaseAsync(string databaseId, bool throwExceptionIfAlreadyExisting = true)
        {
            try
            {
                var databaseUri = UriFactory.CreateDatabaseUri(databaseId);
                await this._documentClient.ReadDatabaseAsync(databaseUri);
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    if (throwExceptionIfAlreadyExisting)
                    {
                        throw new Exception("Database already exists.");
                    }

                    var databaseDefinition = new Database { Id = databaseId };
                    var result = await this._documentClient.CreateDatabaseAsync(databaseDefinition);
                    // The db object is returned to qury as necessary
                    Database database = result.Resource;

                }
                else
                {
                    //_diagnosticsTracingService.Trace(TraceLevel.Error, "Could not query as to whether DocumentDB database exists or not." + e.Message);

                    throw;
                }
            }
        }


        /// <summary>
        /// Gets the list of ids of existing document collections.
        /// </summary>
        /// <param name="databaseId">The database identifier.</param>
        /// <returns>an array of document ids.</returns>
        public string[] GetDocumentCollectionIds(string databaseId)
        {
            Database database = null;

            var databaseUri = UriFactory.CreateDatabaseUri(databaseId);
            var results = this._documentClient.CreateDocumentCollectionQuery(databaseUri).Select(x => x.Id).ToArray();
            return results;
        }


        public void CreateDocumentCollection(string databaseId, string collectionId,
            bool throwExceptionIfAlreadyExists = true, string[] keyColumnNames = null, int offerThroughput = 1000)
        {
            CreateDocumentCollectionAsync(databaseId, collectionId, throwExceptionIfAlreadyExists, keyColumnNames,
                    offerThroughput)
                .Wait(this._configuration.TimeoutMilliseconds);
        }


        /// <summary>
        /// Creates the document collection if it does not already exist.
        /// <para>
        /// Note that the default pk property is a lowercase string 'id' property.
        /// </para>
        /// </summary>
        /// <param name="databaseId">The database identifier.</param>
        /// <param name="collectionId">The collection identifier.</param>
        /// <param name="throwExceptionIfAlreadyExists">if set to <c>true</c>, throw an exception if the document collection already exists.</param>
        /// <param name="keyColumnNames">The single or composite unique column name(s).</param>
        /// <param name="offerThroughput">The offer throughput.</param>
        /// <returns></returns>
        /// <exception cref="Exception">DocumentDB collection already exists.</exception>
        public async Task CreateDocumentCollectionAsync(string databaseId, string collectionId,
            bool throwExceptionIfAlreadyExists = true, string[] keyColumnNames = null, int offerThroughput = 1000)
        {

            try
            {
                var documentCollectionUri = UriFactory.CreateDocumentCollectionUri(databaseId, collectionId);

                await this._documentClient.ReadDocumentCollectionAsync(documentCollectionUri);
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    if (throwExceptionIfAlreadyExists)
                    {
                        throw new Exception("DocumentDB collection already exists.");
                    }

                    var collectionDefinition = new DocumentCollection { Id = collectionId };

                    // Define unique keys if there are any.
                    if ((keyColumnNames != null) && (keyColumnNames.Length > 0))
                    {
                        for (int i = 0; i < keyColumnNames.Length; i++)
                        {
                            // ensure column names are expressed as paths:
                            if (!keyColumnNames[i].StartsWith("/"))
                            {
                                keyColumnNames[i] = "/" + keyColumnNames[i];
                            }
                        }
                        collectionDefinition.UniqueKeyPolicy = new UniqueKeyPolicy
                        {
                            UniqueKeys = new Collection<UniqueKey>()
                            {
                                new UniqueKey() {Paths = new Collection<string>(keyColumnNames)}
                            }
                        };
                    }
                    var databaseUri = UriFactory.CreateDatabaseUri(databaseId);

                    var result =
                        await this._documentClient.CreateDocumentCollectionAsync(
                            databaseUri,
                            collectionDefinition,
                            new RequestOptions { OfferThroughput = 1000 }
                        );
                    DocumentCollection documentCollection = result.Resource;
                }
                else
                {
                    throw;
                }
            }
        }


        /// <summary>
        /// Gets the count of the documents in the specified documentCollection.
        /// </summary>
        /// <param name="databaseId">The database identifier.</param>
        /// <param name="collectionId">The collection identifier.</param>
        /// <returns></returns>
        public int GetDocumentCount(string databaseId, string collectionId)
        {
            Uri collectionUri = UriFactory.CreateDocumentCollectionUri(databaseId, collectionId);
            return GetDocumentCount(collectionUri);

        }


        /// <summary>
        /// Gets the count of the documents in the specified documentCollection.
        /// </summary>
        /// <param name="documentUri">The document URI.</param>
        /// <returns></returns>
        public int GetDocumentCount(Uri documentUri)
        {

            var result = this._documentClient.CreateDocumentQuery(documentUri).Count();
            return result;
        }



        public void SaveDocument<TDocument>(string databaseId, string collectionId, TDocument document)
        {
            // Can come up with the following:
            //DocumentClientException: Message: {"Errors":["Resource with specified id or name already exists

            SaveDocumentAsync<TDocument>(databaseId, collectionId, document)
                .Wait(this._configuration.TimeoutMilliseconds);
        }


        /// <summary>
        /// Saves the object/document for the first time.
        /// <para>
        /// The 'document' can be any class.
        /// </para>
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="databaseId">The database identifier.</param>
        /// <param name="collectionId">The collection identifier.</param>
        /// <param name="document">The document to save.</param>
        /// <returns></returns>
        public async Task SaveDocumentAsync<TDocument>(string databaseId, string collectionId, TDocument document)
        {
            Uri collectionUri = UriFactory.CreateDocumentCollectionUri(databaseId, collectionId);

            await SaveDocumentAsync(collectionUri, document);
        }

        /// <summary>
        /// Saves the object/document for the first time.
        /// <para>
        /// The 'document' can be any class.
        /// </para>
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="collectionLinkUri">The collection link URI.</param>
        /// <param name="document">The document.</param>
        /// <returns></returns>
        public async Task SaveDocumentAsync<TDocument>(Uri collectionLinkUri, TDocument document)
        {
            await this._documentClient.CreateDocumentAsync(collectionLinkUri, document);
        }

        /// <summary>
        /// Retrieve a single document/object.
        /// <para>
        /// The 'document' can be any class, queried using a predicate of either its properties, 
        /// or a addendum storage attribute.
        /// </para>
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="databaseId">The database identifier.</param>
        /// <param name="collectionId">The collection identifier.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public async Task<TDocument> GetDocumentAsync<TDocument>(string databaseId, string collectionId,
            Func<TDocument, bool> predicate)
        {
            var documentCollectionUri = UriFactory.CreateDocumentCollectionUri(databaseId, collectionId);
            return await GetDocumentAsync(documentCollectionUri, predicate);
        }

        /// <summary>
        /// Retrieve a single document/object.
        /// <para>
        /// The 'document' can be any class, queried using a predicate of either its properties,
        /// or a addendum storage attribute.
        /// </para>
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="collectionLinkUri">The collection link URI.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public async Task<TDocument> GetDocumentAsync<TDocument>(Uri collectionLinkUri, Func<TDocument, bool> predicate)
        {
            var documentQuery = CreateDocumentQuery<TDocument>(collectionLinkUri, new SqlQuerySpec());
            TDocument result = documentQuery.FirstOrDefault(predicate);
            return result;
        }


        /// <summary>
        /// Retrive a single object 
        /// CURRENTLY THIS IS UNTESTED
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="collectionLinkUri">The collection link URI.</param>
        /// <param name="settings">The Newtonsoft settings to translate the document </param>
        /// <returns></returns>
        public async Task<TDocument> GetDocumentAsync<TDocument>(Uri collectionLinkUri, JsonSerializerSettings settings)
        {
            var response = await this._documentClient.ReadDocumentAsync(collectionLinkUri);
            return JsonConvert.DeserializeObject<TDocument>(response.Resource.ToString(), settings);
        }



        /// <summary>
        /// Persists the updated document/object.
        /// <para>
        /// The 'document' can be any class.
        /// </para>
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="databaseId">The database identifier.</param>
        /// <param name="collectionId">The collection identifier.</param>
        /// <param name="documentId">The document identifier.</param>
        /// <param name="updatedDocument">The updated document.</param>
        /// <param name="throwExceptionIfNotFound">if set to <c>true</c> [throw exception if not found].</param>
        /// <returns></returns>
        public async Task UpdateDocumentAsync<TDocument>(string databaseId, string collectionId, string documentId,
            TDocument updatedDocument, bool throwExceptionIfNotFound = true)
        {
            Uri documentUri = UriFactory.CreateDocumentUri(databaseId, collectionId, documentId);
            await UpdateDocumentAsync<TDocument>(documentId, collectionId, updatedDocument, documentUri,
                throwExceptionIfNotFound);
        }

        /// <summary>
        /// Persists the updated document/object.
        /// <para>
        /// The 'document' can be any class.
        /// </para>
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="databaseId">The database identifier.</param>
        /// <param name="collectionId">The collection identifier.</param>
        /// <param name="documentUri">The document self link.</param>
        /// <param name="updatedDocument">The updated document.</param>
        /// <param name="throwExceptionIfNotFound">if set to <c>true</c> [throw exception if not found].</param>
        /// <returns></returns>
        /// <exception cref="Exception">Document not found.</exception>
        public async Task UpdateDocumentAsync<TDocument>(string databaseId, string collectionId,
            TDocument updatedDocument,
            Uri documentUri = null, bool throwExceptionIfNotFound = true)
        {
            if (documentUri == null)
            {
                var documentId = GetDocumentIdByReflection(updatedDocument);
                documentUri = UriFactory.CreateDocumentUri(databaseId, collectionId, documentId);
            }
            try
            {

                await this._documentClient.ReplaceDocumentAsync(documentUri, updatedDocument);
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    if (throwExceptionIfNotFound)
                    {
                        throw new Exception("Document not found.");
                    }
                    await SaveDocumentAsync(databaseId, collectionId, updatedDocument);
                }
            }
        }

        // Uri to a document:
        //dbs/MyDatabaseId/colls/MyCollectionId/docs/MyDocumentId 

        public void PersistDocument<TDocument>(string databaseId, string collectionId, TDocument document,
            bool saveBeforeUpdate = true)
        {
            PersistDocumentAsync(databaseId, collectionId, document).Wait(this._configuration.TimeoutMilliseconds);
        }


        public async Task PersistDocumentAsync<TDocument>(string databaseId, string collectionId, TDocument document,
            bool saveBeforeUpdate = true)
        {
            try
            {
                await SaveDocumentAsync(databaseId, collectionId, document);
            }
            catch (DocumentClientException e)
            {
                var check = e.StatusCode;

                // 409.
                if (e.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    var documentId = GetDocumentIdByReflection(document);
                    Uri documentUri = UriFactory.CreateDocumentUri(databaseId, collectionId, documentId);

                    await this._documentClient.ReplaceDocumentAsync(documentUri, document);

                }
            }

        }



        public void DeleteDocument(Document document, bool throwExceptionIfNotFound = true)
        {
            DeleteDocumentAsync(document, throwExceptionIfNotFound).Wait(this._configuration.TimeoutMilliseconds);
        }

        public void DeleteDocument<TDocument>(string databaseId, string collectionId, TDocument document,
            bool throwExceptionIfNotFound = true)
        {
            DeleteDocumentAsync(databaseId, collectionId, document).Wait(this._configuration.TimeoutMilliseconds);
        }

        public void DeleteDocument(string databaseId, string collectionId, string documentId,
            bool throwExceptionIfNotFound = true)
        {
            DeleteDocumentAsync(databaseId, collectionId, documentId).Wait(this._configuration.TimeoutMilliseconds);
        }

        public void DeleteDocument(Uri documentUri, bool throwExceptionIfNotFound = true)
        {
            DeleteDocumentAsync(documentUri).Wait(this._configuration.TimeoutMilliseconds);
        }



        public async Task DeleteDocumentAsync(Document document, bool throwExceptionIfNotFound = true)
        {
            await DeleteDocumentAsync(new Uri(document.SelfLink), throwExceptionIfNotFound);
        }


        public async Task DeleteDocumentAsync<TDocument>(string databaseId, string collectionId, TDocument document,
            bool throwExceptionIfNotFound = true)
        {
            string documentId = GetDocumentIdByReflection(document);
            await DeleteDocumentAsync(databaseId, collectionId, documentId);
        }

        public async Task DeleteDocumentAsync(string databaseId, string collectionId, string documentId,
            bool throwExceptionIfNotFound = true)
        {
            Uri documentUri = UriFactory.CreateDocumentUri(databaseId, collectionId, documentId);

            await DeleteDocumentAsync(documentUri);
        }

        public async Task DeleteDocumentAsync(Uri documentUri, bool throwExceptionIfNotFound = true)
        {
            try
            {
                await this._documentClient.DeleteDocumentAsync(documentUri);
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    if (throwExceptionIfNotFound)
                    {
                        throw new Exception("Document not found.");
                    }
                }
            }
        }


        public void DeleteAllDocuments(string databaseId, string collectionId)
        {
            DeleteAllDocumentsAsync(databaseId, collectionId).Wait(this._configuration.TimeoutMilliseconds);
        }

        public async Task DeleteAllDocumentsAsync(string databaseId, string collectionId)
        {
            Uri collectionUri = UriFactory.CreateDocumentCollectionUri(databaseId, collectionId);

            //foreach (var x in this._documentClient.CreateDocumentQuery(collectionUri))
            //{
            //    await DeleteDocumentAsync(databaseId, collectionId, x);
            //}
            // TODO: This won't work if there are more than 100 records. 
            // https://steveblank.com/2018/04/11/why-entrepreneurs-start-companies-rather-than-join-them/

            //So do it this way:
            var r = _documentClient.CreateDocumentQuery(collectionUri).AsDocumentQuery();
            while (r.HasMoreResults)
            {
                foreach (Document x in await r.ExecuteNextAsync())
                {
                    await this._documentClient.DeleteDocumentAsync(x.SelfLink);
                }
            }
        }


        public void DeleteDocuments<TDocument>(string databaseId, string collectionId, Func<TDocument, bool> predicate)
        {
            DeleteDocumentsAsync(databaseId, collectionId, predicate).Wait(this._configuration.TimeoutMilliseconds);
        }



        public async Task DeleteDocumentsAsync<TDocument>(string databaseId, string collectionId, Func<TDocument, bool> predicate)
        {
            if (predicate == null)
            {
                predicate = x => true;
            }

            //Issue our query against the collection
            Uri collectionUri = UriFactory.CreateDocumentCollectionUri(databaseId, collectionId);

            foreach (var x in this._documentClient.CreateDocumentQuery<TDocument>(collectionUri).Where(predicate).AsEnumerable())
            {
                await DeleteDocumentAsync(databaseId, collectionId, x);
            }

            // Don't yet understand how to mix Queryability and AsDocumentQuery()
            //var r = this._documentClient.CreateDocumentQuery<TDocument>(collectionUri).Where(predicate).AsDocumentQuery();
            //var r = this._documentClient.CreateDocumentQuery(collectionUri).Where(predicate).AsDocumentQuery();
            
            // r.HasMoreResults
            foreach (var x in this._documentClient.CreateDocumentQuery<TDocument>(collectionUri).Where(predicate))
            {
                await DeleteDocumentAsync(databaseId, collectionId, x);
            }
            // TODO: This won't work if there are more than 100 records. 
            // https://steveblank.com/2018/04/11/why-entrepreneurs-start-companies-rather-than-join-them/

        }





        /// <summary>
        /// Deletes the document collection.
        /// </summary>
        /// <param name="databaseId">The database identifier.</param>
        /// <param name="collectionId">The collection identifier.</param>
        /// <param name="throwExceptionIfNotFound">if set to <c>true</c> [throw exception if not found].</param>
        public void DeleteDocumentCollection(string databaseId, string collectionId, bool throwExceptionIfNotFound = true)
        {
            DeleteDocumentCollectionAsync(databaseId, collectionId, throwExceptionIfNotFound).Wait(this._configuration.TimeoutMilliseconds);
        }

        public async Task DeleteDocumentCollectionAsync(string databaseId, string collectionId, bool throwExceptionIfNotFound = true)
        {
            Uri collectionUri = UriFactory.CreateDocumentCollectionUri(databaseId, collectionId);
            await DeleteDocumentCollectionAsync(collectionUri, throwExceptionIfNotFound);
        }


        public void DeleteDocumentCollection(Uri collectionUri, bool throwExceptionIfNotFound = true)
        {
            DeleteDocumentCollectionAsync(collectionUri, throwExceptionIfNotFound).Wait(this._configuration.TimeoutMilliseconds);
        }

        public async Task DeleteDocumentCollectionAsync(Uri collectionUri, bool throwExceptionIfNotFound = true)
        {
            try
            {
                var response = await this._documentClient.DeleteDocumentCollectionAsync(collectionUri);
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    if (throwExceptionIfNotFound)
                    {
                        throw new Exception("Document Collection not found.");
                    }
                }
            }
        }
        public async Task DeleteDatabaseAsync(Database database, bool throwExceptionIfNotFound = true)
        {
            await DeleteDatabaseAsync(new Uri(database.SelfLink), throwExceptionIfNotFound);
        }
        public async Task DeleteDatabaseAsync(string databaseId, bool throwExceptionIfNotFound = true)
        {
            Uri databaseUri = UriFactory.CreateDatabaseUri(databaseId);
            await DeleteDatabaseAsync(databaseUri, throwExceptionIfNotFound);
        }
        public async Task DeleteDatabaseAsync(Uri collectionUri, bool throwExceptionIfNotFound = true)
        {
            try
            {
                await this._documentClient.DeleteDatabaseAsync(collectionUri);
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    if (throwExceptionIfNotFound)
                    {
                        throw new Exception("Database not found.");
                    }
                }
            }
        }

    }
}
