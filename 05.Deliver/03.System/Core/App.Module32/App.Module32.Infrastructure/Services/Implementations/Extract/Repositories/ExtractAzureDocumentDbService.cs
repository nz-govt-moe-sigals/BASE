using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App.Core.Infrastructure.Services;
using App.Core.Infrastructure.Services.Implementations;
using App.Module32.Infrastructure.Services.Configuration;
using App.Module32.Shared.Models.Configuration;
using App.Module32.Shared.Models.Messages.Extract.Base;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;

namespace App.Module32.Infrastructure.Services.Implementations.Extract.Repositories
{
    public class ExtractAzureDocumentDbService  :AzureDocumentDbBaseService,  IExtractAzureDocumentDbService
    {
        private readonly ExtractDocumentDbConfig _configuration;
        private readonly SemaphoreSlim mutex = new SemaphoreSlim(1);
        private volatile string _responseContinuationToken;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtractAzureDocumentDbService"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="diagnosticsTracingService">The diagnostics tracing service.</param>
        public ExtractAzureDocumentDbService(ExtractDocumentDbServiceConfiguration configuration,
            IDiagnosticsTracingService diagnosticsTracingService)
            : base(configuration.Config.EndpointUrl,
                configuration.Config.AuthorizationKey,
                diagnosticsTracingService)
        {
            this._configuration = configuration.Config;
        }


        public ExtractDocumentDbConfig Configuration 
        {
            get => _configuration;
        }

        public int PageQuerySize
        {
            get
            {
                if (Configuration != null)
                {
                    return Configuration.PageQuerySize;
                }
                return 100;
            }
        }



        public IQueryable<TDocument> GetDocuments<TDocument>(string tableName, DateTime watermarkDate)
            where TDocument : BaseMessage
        {
            return base.GetDocuments<TDocument>(Configuration.DatabaseName, Configuration.CollectionName)
                .Where(x => x.TableName == tableName && x.ModifiedDate > watermarkDate)
                .OrderBy(x => x.ModifiedDate);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <returns></returns>
        public async Task<IEnumerable<TDocument>> ExecuteGetDocumentsAsync<TDocument>(string tableName, DateTime watermarkDate)
            where TDocument : BaseMessage
        {
            await mutex.WaitAsync().ConfigureAwait(false);
            try
            {
                var query = GetDocumentsQueryAsync<TDocument>(tableName, watermarkDate).AsDocumentQuery();
                var result = await base.ExecuteDocumentDbWithRetries(() => query.ExecuteNextAsync<TDocument>());
                _responseContinuationToken = result.ResponseContinuation;
                return result.AsEnumerable();
            }
            finally
            {
                mutex.Release();
            }
         
        }

        private IQueryable<TDocument> GetDocumentsQueryAsync<TDocument>(string tableName, DateTime watermarkDate)
            where TDocument : BaseMessage
        {
            return base.GetDocuments<TDocument>(Configuration.DatabaseName, Configuration.CollectionName,
                    new FeedOptions()
                    {
                        MaxItemCount = PageQuerySize,
                        EnableCrossPartitionQuery = true,
                        RequestContinuation = _responseContinuationToken
                    })
                .Where(x => x.TableName == tableName && x.ModifiedDate > watermarkDate)
                .OrderBy(x => x.ModifiedDate);
        }

    }
}











