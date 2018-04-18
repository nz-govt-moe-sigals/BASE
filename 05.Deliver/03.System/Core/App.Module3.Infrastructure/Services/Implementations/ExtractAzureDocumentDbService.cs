using App.Core.Infrastructure.Services;
using App.Module3.Infrastructure.Services.Implementations.Configuration;
using App.Module3.Shared.Models.Messages.Extract;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module3.Infrastructure.Services.Implementations
{
    public class ExtractAzureDocumentDbService : IExtractAzureDocumentDbService
    {
        private ExtractDocumentDbServiceConfiguration _configuration;
        private IDiagnosticsTracingService _diagnosticsTracingService;

        public ExtractDocumentDbServiceConfiguration Configuration
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
        public ExtractAzureDocumentDbService(ExtractDocumentDbServiceConfiguration configuration,
            IDiagnosticsTracingService diagnosticsTracingService)
        {
            this._configuration = configuration;
            _diagnosticsTracingService = diagnosticsTracingService;

            //sooo hardcoded
            this._configuration = new ExtractDocumentDbServiceConfiguration()
            {
                EndpointUrl = new Uri("https://nzmoebase.documents.azure.com:443/"),
                AuthorizationKey = "wEDBI7B1MPHtNK4y2Myi1h5falYVviMuVBQHgI9hUzT4HnLxsRCJzUC4BPvXW2XEzPJHFztRzhpRK6lBI3NG6A==",
                CollectionName= "syncData",
                DatabaseName="dataFactory"
            };

        }

        private DocumentClient CreateClient()
        {
            return new DocumentClient(this._configuration.EndpointUrl, this._configuration.AuthorizationKey);
        }

        private DocumentClient CreateClient(JsonSerializerSettings jsonSerializerSettings)
        {
            return new DocumentClient(this._configuration.EndpointUrl, this._configuration.AuthorizationKey, jsonSerializerSettings);
        }

        public IList<TDocument> GetDocuments<TDocument>(JsonSerializerSettings settings, string dbName)
            where TDocument : BaseMessage
        {
            return GetDocuments<TDocument>(this._configuration.DatabaseName, this._configuration.CollectionName, settings, dbName);
        }


        public IList<TDocument> GetDocuments<TDocument>(string databaseId, string collectionId, JsonSerializerSettings settings, string dbName)
            where TDocument : BaseMessage
        {
            var documentCollectionUri = UriFactory.CreateDocumentCollectionUri(databaseId, collectionId);
            return GetDocuments<TDocument>(documentCollectionUri, settings, dbName);
        }

        public IList<TDocument> GetDocuments<TDocument>(Uri collectionLinkUri, JsonSerializerSettings settings, string dbName)
            where TDocument: BaseMessage
        {
            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery=true  };
            var list = new List<TDocument>();
            using (var documentClient = CreateClient(settings))
            {
                return documentClient.CreateDocumentQuery<TDocument>(collectionLinkUri, queryOptions)
                    .Where(x => x.TableName == dbName).ToList();
            }
                
        }

    }
}
