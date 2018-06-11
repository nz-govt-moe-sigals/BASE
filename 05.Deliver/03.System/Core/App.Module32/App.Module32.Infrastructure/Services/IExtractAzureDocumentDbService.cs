﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Module32.Shared.Models.Messages.Extract.Base;

namespace App.Module32.Infrastructure.Services
{
    public interface IExtractAzureDocumentDbService
    {
        IQueryable<TDocument> GetDocuments<TDocument>(string dbName, DateTime watermarkDate)
            where TDocument : BaseMessage;

        Task<IEnumerable<TDocument>> ExecuteGetDocumentsAsync<TDocument>(string tableName, DateTime watermarkDate)
            where TDocument : BaseMessage;

        int PageQuerySize { get; }
    }
}