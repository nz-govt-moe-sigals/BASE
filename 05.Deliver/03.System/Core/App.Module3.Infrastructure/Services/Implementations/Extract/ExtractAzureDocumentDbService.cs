using System;
using System.Linq;
using App.Core.Infrastructure.Services;
using App.Core.Infrastructure.Services.Implementations.Base;
using App.Module3.Infrastructure.Services.Implementations.Configuration;
using App.Module3.Shared.Models.Messages.Extract;

namespace App.Module3.Infrastructure.Services.Implementations.Extract
{
    public class ExtractAzureDocumentDbService  :AzureDocumentDbBaseService,  IExtractAzureDocumentDbService
    {
        private readonly ExtractDocumentDbServiceConfiguration _configuration;

        public ExtractDocumentDbServiceConfiguration Configuration 
        {
            get => _configuration;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtractAzureDocumentDbService"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="diagnosticsTracingService">The diagnostics tracing service.</param>
        public ExtractAzureDocumentDbService(ExtractDocumentDbServiceConfiguration configuration,
            IDiagnosticsTracingService diagnosticsTracingService)
            :base(new Uri("https://nzmoebase.documents.azure.com:443/"), 
                 "wEDBI7B1MPHtNK4y2Myi1h5falYVviMuVBQHgI9hUzT4HnLxsRCJzUC4BPvXW2XEzPJHFztRzhpRK6lBI3NG6A==", 
                 diagnosticsTracingService)
        {
            this._configuration = configuration;

            //sooo hardcoded
            this._configuration = new ExtractDocumentDbServiceConfiguration()
            {
                EndpointUrl = new Uri("https://nzmoebase.documents.azure.com:443/"),
                AuthorizationKey = "wEDBI7B1MPHtNK4y2Myi1h5falYVviMuVBQHgI9hUzT4HnLxsRCJzUC4BPvXW2XEzPJHFztRzhpRK6lBI3NG6A==",
                CollectionName= "syncData",
                DatabaseName="dataFactory"
            };

        }

        public IQueryable<TDocument> GetDocuments<TDocument>(string tableName, DateTime watermarkDate)
            where TDocument : BaseMessage
        {
            return base.GetDocuments<TDocument>(Configuration.DatabaseName, Configuration.CollectionName)
                .Where(x => x.TableName == tableName && x.ModifiedDate > watermarkDate);
        }

    }
}
