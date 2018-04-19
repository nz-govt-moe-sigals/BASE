using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services
{
    public interface IHasAzureDocumentDbBaseService
    {
        IQueryable<TDocument> GetDocuments<TDocument>(string databaseId, string collectionId);

        IQueryable<TDocument> GetDocuments<TDocument>(Uri collectionLinkUri);

        IQueryable<TDocument> GetDocuments<TDocument>(string databaseId, string collectionId, FeedOptions feedoptions);

        IQueryable<TDocument> GetDocuments<TDocument>(Uri collectionLinkUri, FeedOptions feedoptions);
    }
}
