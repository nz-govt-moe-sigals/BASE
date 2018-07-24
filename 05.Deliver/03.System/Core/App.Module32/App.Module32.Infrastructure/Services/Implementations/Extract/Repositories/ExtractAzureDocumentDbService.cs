using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App.Core.Infrastructure.Services;
using App.Core.Infrastructure.Services.Implementations;
using App.Module32.Infrastructure.Services.Configuration;
using App.Module32.Shared.Models.Configuration;
using App.Module32.Shared.Models.Messages.Extract;
using App.Module32.Shared.Models.Messages.Extract.Base;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace App.Module32.Infrastructure.Services.Implementations.Extract.Repositories
{
    /// <summary>
    /// Azure Document DB is really finicky with its names and JSON serialisation
    /// So had to extract this into many differnt versions with a few overrides
    /// </summary>
    /// <typeparam name="TDocument"></typeparam>
    public abstract class ExtractAzureDocumentDbService<TDocument> : AzureDocumentDbBaseService, IExtractAzureDocumentDbService<TDocument>
    {
        private readonly SemaphoreSlim _mutex = new SemaphoreSlim(1);
        private volatile string _responseContinuationToken;

        private IContractResolver _resolver = new DefaultContractResolver();

        /// <summary>
        /// Initializes a new instance of the <see /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="diagnosticsTracingService">The diagnostics tracing service.</param>
        protected ExtractAzureDocumentDbService(ExtractDocumentDbServiceConfiguration configuration,
            IDiagnosticsTracingService diagnosticsTracingService)
            : base(configuration.Config.EndpointUrl,
                configuration.Config.AuthorizationKey,
                diagnosticsTracingService)
        {
            this.Configuration = configuration.Config;
            SourceTableName = ExtractConstants.LookupTableNameList(typeof(TDocument));
        }

        public string SourceTableName { get; }

        public ExtractDocumentDbConfig Configuration { get; }


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

        /// <summary>
        /// Will return the PageQuerySize with how GetDocumentsQuery is overriden
        /// continue to call until no longer needed
        /// this the way of sort of doing a doing a Group by , since Group by is not allowed. 
        /// Also the way of doing paging
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <returns></returns>
        public virtual async Task<IEnumerable<TDocument>> ExecuteGetDocumentsAsync(DateTime watermarkDate)
        {
            await _mutex.WaitAsync().ConfigureAwait(false);
            try
            {
                var query = GetDocumentsQuery(watermarkDate).AsDocumentQuery();
                var result = await base.ExecuteDocumentDbWithRetries(() => query.ExecuteNextAsync<TDocument>());
                _responseContinuationToken = result.ResponseContinuation;
                return result.AsEnumerable();
            }
            finally
            {
                _mutex.Release();
            }

        }


        /// <summary>
        /// override to do something like 
        ///  return GetAllDocuments().Count(predicate)
        /// </summary>
        /// <param name="watermarkDate"></param>
        /// <returns></returns>
        public abstract int GetDocumentCount(DateTime watermarkDate);

        /// <summary>
        /// override with GetDocumentsWithContinuationToken.Where(predicate).Orderby(pred)
        /// </summary>
        /// <param name="watermarkDate"></param>
        /// <returns></returns>
        protected abstract IQueryable<TDocument> GetDocumentsQuery(DateTime watermarkDate);

         /// <summary>
         /// the base Query to get all documents, should be advised you should probably only use aggregate functions for this
         /// </summary>
         /// <returns></returns>
        protected IQueryable<TDocument> GetAllDocuments()
        {
            return base.GetDocuments<TDocument>(Configuration.DatabaseName, Configuration.CollectionName);
        }

        /// <summary>
        /// Sets up to use a continuationToken (paging)
        /// </summary>
        /// <returns></returns>
        protected IQueryable<TDocument> GetDocumentsWithContinuationToken()
        {
            return base.GetDocuments<TDocument>(Configuration.DatabaseName, Configuration.CollectionName,
                new FeedOptions()
                {
                    MaxItemCount = PageQuerySize,
                    EnableCrossPartitionQuery = true,
                    RequestContinuation = _responseContinuationToken
                });
        }





    }
}











