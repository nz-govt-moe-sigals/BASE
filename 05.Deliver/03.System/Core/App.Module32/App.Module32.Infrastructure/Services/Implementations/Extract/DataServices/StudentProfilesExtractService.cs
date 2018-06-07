using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Services;
using App.Module32.Infrastructure.Services.Implementations.Base;
using App.Module32.Shared.Models.Messages.Extract;

namespace App.Module32.Infrastructure.Services.Implementations.Extract.DataServices
{
    public class StudentProfilesExtractService : BaseExtractService<StudentProfile>
    {
        public StudentProfilesExtractService(IDiagnosticsTracingService tracingService, IExtractAzureDocumentDbService documentDbService)
            : base(tracingService, documentDbService)
        {
        }
    }
}
