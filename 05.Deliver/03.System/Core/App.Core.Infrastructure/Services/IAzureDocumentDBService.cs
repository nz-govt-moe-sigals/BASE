using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Requires Nuget: Microsoft.Azure.DocumentDB
//using Microsoft.Azure.Documents;

namespace App.Core.Infrastructure.Services
{
    /// <summary>
    /// Contract for an INfrastructure Service
    /// to manage interactions with Azure DocumentDB 
    /// databases, collections and documents.
    /// <para>
    /// Note that by default DocumentDB automatically assigns a unique 
    /// string id to a document. If you want you take over the creation
    /// of these keys, either create your document objects with a string id 
    /// (and set it using a sequential Guid, developed in the constructor)
    /// or decorate an existing property (which may have a different name or case)
    /// with `[JsonProperty(PropertyName = "id")]`
    /// </para>
    /// </summary>
    public interface IAzureDocumentDBService
    {



        Task<string[]> GetDatabaseIds();

        /// <summary>
        /// Creates the defined database if it does not already exist.
        /// </summary>
        /// <param name="databaseId">The database identifier.</param>
        /// <param name="throwExceptionIfAlreadyExisting">if set to <c>true</c>, throws an exception if the database already existing.</param>
        /// <returns></returns>
        void CreateDatabase(string databaseId, bool throwExceptionIfAlreadyExisting = true);


        /// <summary>
        /// Creates the defined database if it does not already exist.
        /// </summary>
        /// <param name="databaseId">The database identifier.</param>
        /// <param name="throwExceptionIfAlreadyExisting">if set to <c>true</c>, throws an exception if the database already existing.</param>
        /// <returns></returns>
        Task CreateDatabaseAsync(string databaseId, bool throwExceptionIfAlreadyExisting = true);



        /// <summary>
        /// Gets the list of ids of existing document collections.
        /// </summary>
        /// <param name="databaseId">The database identifier.</param>
        /// <returns>an array of document ids.</returns>
        string[] GetDocumentCollectionIds(string databaseId);

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
        void CreateDocumentCollection(string databaseId, string collectionId, bool throwExceptionIfAlreadyExists = true, string[] keyColumnNames = null, int offerThroughput = 1000);


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
        Task CreateDocumentCollectionAsync(string databaseId, string collectionId, bool throwExceptionIfAlreadyExists = true, string[] keyColumnNames = null, int offerThroughput = 1000);



        /// <summary>
        /// Gets the count of the documents in the specified documentCollection.
        /// </summary>
        /// <param name="databaseId">The database identifier.</param>
        /// <param name="collectionId">The collection identifier.</param>
        /// <returns></returns>
        int GetDocumentCount(string databaseId, string collectionId);


        /// <summary>
        /// Gets the count of the documents in the specified documentCollection.
        /// </summary>
        /// <param name="documentUri">The document URI.</param>
        /// <returns></returns>
        int GetDocumentCount(Uri documentUri);

        /// <summary>
        /// Saves the object/document for the first time.
        /// <para>
        /// The 'document' can be any class.
        /// </para>
        /// <para>
        /// Note that the default pk property is a lowercase string 'id' property.
        /// </para>
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="documentId">The document identifier.</param>
        /// <param name="collectionId">The collection identifier.</param>
        /// <param name="document">The document to save.</param>
        /// <returns></returns>
        void SaveDocument<TDocument>(string documentId, string collectionId, TDocument document);

        /// <summary>
        /// Saves the object/document for the first time.
        /// <para>
        /// The 'document' can be any class.
        /// </para>
        /// <para>
        /// Note that the default pk property is a lowercase string 'id' property.
        /// </para>
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="documentId">The document identifier.</param>
        /// <param name="collectionId">The collection identifier.</param>
        /// <param name="document">The document to save.</param>
        /// <returns></returns>
        Task SaveDocumentAsync<TDocument>(string documentId, string collectionId, TDocument document);
        /// <summary>
        /// Saves the object/document for the first time.
        /// <para>
        /// The 'document' can be any class.
        /// </para>
        /// <para>
        /// Note that the default pk property is a lowercase string 'id' property.
        /// </para>
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="collectionLinkUri">The collection link URI.</param>
        /// <param name="document">The document.</param>
        /// <returns></returns>
        Task SaveDocumentAsync<TDocument>(Uri collectionLinkUri, TDocument document);



        /// <summary>
        /// Retrieve a single document/object.
        /// <para>
        /// The 'document' can be any class, queried using a predicate of either its properties, 
        /// or a addendum storage attribute.
        /// </para>
        /// <para>
        /// Note that the default pk property is a lowercase string 'id' property.
        /// </para>
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="databaseId">The database identifier.</param>
        /// <param name="collectionId">The collection identifier.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        Task<TDocument> GetDocumentAsync<TDocument>(string databaseId, string collectionId, Func<TDocument, bool> predicate);

        /// <summary>
        /// Retrieve a single document/object.
        /// <para>
        /// The 'document' can be any class, queried using a predicate of either its properties, 
        /// or a addendum storage attribute.
        /// </para>
        /// <para>
        /// Note that the default pk property is a lowercase string 'id' property.
        /// </para>
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="collectionLinkUri">The collection link URI.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        Task<TDocument> GetDocumentAsync<TDocument>(Uri collectionLinkUri, Func<TDocument, bool> predicate);


        /// <summary>
        /// Retrive a single object 
        /// CURRENTLY THIS IS UNTESTED
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="collectionLinkUri">The collection link URI.</param>
        /// <param name="settings">The Newtonsoft settings to translate the document </param>
        /// <returns></returns>
        Task<TDocument> GetDocumentAsync<TDocument>(Uri collectionLinkUri, JsonSerializerSettings settings);



        /// <summary>
        /// Persists the updated document/object.
        /// <para>
        /// The 'document' can be any class.
        /// </para>
        /// <para>
        /// Note that the default pk property is a lowercase string 'id' property.
        /// </para>
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="databaseId">The database identifier.</param>
        /// <param name="collectionId">The collection identifier.</param>
        /// <param name="documentId">The document identifier.</param>
        /// <param name="updatedDocument">The updated document.</param>
        /// <param name="throwExceptionIfNotFound">if set to <c>true</c> [throw exception if not found].</param>
        /// <returns></returns>
        Task UpdateDocumentAsync<TDocument>(string databaseId, string collectionId, string documentId, TDocument updatedDocument, bool throwExceptionIfNotFound = true);

        /// <summary>
        /// Persists the updated document/object.
        /// <para>
        /// The 'document' can be any class.
        /// </para>
        /// <para>
        /// Note that the default pk property is a lowercase string 'id' property.
        /// </para>
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="databaseId">The database identifier.</param>
        /// <param name="collectionId">The collection identifier.</param>
        /// <param name="documentUri">The document self link.</param>
        /// <param name="updatedDocument">The updated document.</param>
        /// <param name="throwExceptionIfNotFound">if set to <c>true</c> [throw exception if not found].</param>
        /// <returns></returns>
        Task UpdateDocumentAsync<TDocument>(string databaseId, string collectionId, TDocument updatedDocument, Uri documentUri = null, bool throwExceptionIfNotFound = true);



        void PersistDocument<TDocument>(string databaseId, string collectionId, TDocument document, bool saveBeforeUpdate = true);


        Task PersistDocumentAsync<TDocument>(string databaseId, string collectionId, TDocument document, bool saveBeforeUpdate = true);





        /// <summary>
        /// Deletes all documents.
        /// </summary>
        /// <param name="documentId">The document identifier.</param>
        /// <param name="collectionId">The collection identifier.</param>
        void DeleteAllDocuments(string documentId, string collectionId);
        /// <summary>
        /// Deletes all documents asynchronous.
        /// </summary>
        /// <param name="documentId">The document identifier.</param>
        /// <param name="collectionId">The collection identifier.</param>
        /// <returns></returns>
        Task DeleteAllDocumentsAsync(string documentId, string collectionId);



        /// <summary>
        /// Deletes the document/object.
        /// <para>
        /// Note that the default pk property is a lowercase string 'id' property.
        /// </para>
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="throwExceptionIfNotFound">if set to <c>true</c> [throw exception if not found].</param>
        /// <returns></returns>
        //void DeleteDocument(Document document, bool throwExceptionIfNotFound = true);
        void DeleteDocument<TDocument>(string databaseId, string collectionId, TDocument document, bool throwExceptionIfNotFound = true);
        void DeleteDocument(string databaseId, string collectionId, string documentId, bool throwExceptionIfNotFound = true);
        void DeleteDocument(Uri documentUri, bool throwExceptionIfNotFound = true);

        /// <summary>
        /// Deletes the document/object.
        /// <para>
        /// Note that the default pk property is a lowercase string 'id' property.
        /// </para>
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="throwExceptionIfNotFound">if set to <c>true</c> [throw exception if not found].</param>
        /// <returns></returns>
        //Task DeleteDocumentAsync(Document document, bool throwExceptionIfNotFound = true);
        Task DeleteDocumentAsync<TDocument>(string databaseId, string collectionId, TDocument document, bool throwExceptionIfNotFound = true);
        Task DeleteDocumentAsync(string databaseId, string collectionId, string documentId, bool throwExceptionIfNotFound = true);
        /// <summary>
        /// Deletes the document/object.
        /// <para>
        /// Note that the default pk property is a lowercase string 'id' property.
        /// </para>
        /// </summary>
        /// <param name="documentUri">The document self link.</param>
        /// <param name="throwExceptionIfNotFound">if set to <c>true</c> [throw exception if not found].</param>
        /// <returns></returns>
        Task DeleteDocumentAsync(Uri documentUri, bool throwExceptionIfNotFound = true);



        void DeleteDocuments<TDocument>(string databaseId, string collectionId, Func<TDocument, bool> predicate);
        Task DeleteDocumentsAsync<TDocument>(string databaseId, string collectionId, Func<TDocument, bool> predicate);


        /// <summary>
        /// Deletes the document collection.
        /// </summary>
        /// <param name="documentId">The document identifier.</param>
        /// <param name="collectionId">The collection identifier.</param>
        /// <param name="throwExceptionIfNotFound">if set to <c>true</c> [throw exception if not found].</param>
        void DeleteDocumentCollection(string documentId, string collectionId, bool throwExceptionIfNotFound = true);

        /// <summary>
        /// Deletes the document collection.
        /// </summary>
        /// <param name="documentId">The document identifier.</param>
        /// <param name="collectionId">The collection identifier.</param>
        /// <param name="throwExceptionIfNotFound">if set to <c>true</c> [throw exception if not found].</param>
        /// <returns></returns>
        Task DeleteDocumentCollectionAsync(string documentId, string collectionId, bool throwExceptionIfNotFound = true);



        /// <summary>
        /// Deletes the document collection.
        /// </summary>
        /// <param name="collectionUri">The collection URI.</param>
        /// <param name="throwExceptionIfNotFound">if set to <c>true</c> [throw exception if not found].</param>
        void DeleteDocumentCollection(Uri collectionUri, bool throwExceptionIfNotFound = true);

        /// <summary>
        /// Deletes the document collection asynchronous.
        /// </summary>
        /// <param name="collectionUri">The collection URI.</param>
        /// <param name="throwExceptionIfNotFound">if set to <c>true</c> [throw exception if not found].</param>
        /// <returns></returns>
        Task DeleteDocumentCollectionAsync(Uri collectionUri, bool throwExceptionIfNotFound = true);



    }
}
