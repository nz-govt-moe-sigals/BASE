using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Module32.Shared.Models.Messages.Extract.Base;
using Newtonsoft.Json.Serialization;

namespace App.Module32.Infrastructure.Services
{
    public interface IExtractAzureDocumentDbService<TDocument>
    {
        int GetDocumentCount(DateTime watermarkDate);

        Task<IEnumerable<TDocument>> ExecuteGetDocumentsAsync(DateTime watermarkDate);

        int PageQuerySize { get; }

        string SourceTableName { get; }

    }
}
