﻿using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services.Implementations.Base
{
    public abstract class AzureDocumentDbBaseService : IHasAzureDocumentDbBaseService
    {
        protected DocumentClient _documentClient;
        protected IDiagnosticsTracingService _diagnosticsTracingService;

        public AzureDocumentDbBaseService(string endpoint, string authKey,
            IDiagnosticsTracingService diagnosticsTracingService)
            :this (new Uri(endpoint), authKey, diagnosticsTracingService)
        {
            
        }

        public AzureDocumentDbBaseService(Uri endpointUrl, string authKey,
        IDiagnosticsTracingService diagnosticsTracingService)
        {
            _diagnosticsTracingService = diagnosticsTracingService;
            _documentClient = CreateClient(endpointUrl, authKey);
        }

        private DocumentClient CreateClient(Uri endpointUrl, string authorizationKey)
        {
            return new DocumentClient(endpointUrl, authorizationKey);
        }

        public virtual IQueryable<TDocument> GetDocuments<TDocument>(string databaseId, string collectionId)
        {
            var documentCollectionUri = UriFactory.CreateDocumentCollectionUri(databaseId, collectionId);
            return GetDocuments<TDocument>(documentCollectionUri);
        }

        public virtual IQueryable<TDocument> GetDocuments<TDocument>(Uri collectionLinkUri)
        {
            FeedOptions feedoptions = new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true };
            return GetDocuments<TDocument>(collectionLinkUri, feedoptions);
        }

        public virtual IQueryable<TDocument> GetDocuments<TDocument>(string databaseId, string collectionId, FeedOptions feedoptions)
        {
            var documentCollectionUri = UriFactory.CreateDocumentCollectionUri(databaseId, collectionId);
            return GetDocuments<TDocument>(documentCollectionUri, feedoptions);
        }


        public virtual IQueryable<TDocument> GetDocuments<TDocument>(Uri collectionLinkUri, FeedOptions feedoptions)
        {
            return this._documentClient.CreateDocumentQuery<TDocument>(collectionLinkUri, feedoptions);
        }



    }
}
