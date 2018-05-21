using App.Module11.Shared.Models.Messages.Extract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Module11.Infrastructure.Services
{
    public interface IExtractAzureDocumentDbService
    {
        IQueryable<TDocument> GetDocuments<TDocument>(string dbName, DateTime watermarkDate)
            where TDocument : BaseMessage;
    }
}
