using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Module32.Shared.Models.Messages.Extract;

namespace App.Module32.Infrastructure.Services.Interfaces.Extract
{
    public interface ISchoolExtractAzureDocumentDbService : IExtractAzureDocumentDbService<SchoolProfile>
    {
    }
}
