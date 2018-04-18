using App.Module3.Shared.Models.Messages.Extract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module3.Infrastructure.Services
{
    public interface IExtractAzureDocumentDbService
    {
        IQueryable<TDocument> GetDocuments<TDocument>(JsonSerializerSettings settings, string dbName)
            where TDocument : BaseMessage;
    }
}
