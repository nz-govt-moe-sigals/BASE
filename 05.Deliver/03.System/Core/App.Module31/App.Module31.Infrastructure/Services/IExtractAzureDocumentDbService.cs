using App.Module31.Shared.Models.Messages.Extract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Module31.Infrastructure.Services
{
    public interface IExtractAzureDocumentDbService
    {
        IQueryable<TDocument> GetDocuments<TDocument>(string dbName, DateTime watermarkDate)
            where TDocument : BaseMessage;
    }
}





