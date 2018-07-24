using System;
using System.Linq;
using App.Core.Infrastructure.Services;
using App.Module32.Infrastructure.Services.Configuration;
using App.Module32.Infrastructure.Services.Interfaces.Extract;
using App.Module32.Shared.Models.Messages.Extract;

namespace App.Module32.Infrastructure.Services.Implementations.Extract.Repositories
{
    public class StudentExtractAzureDocumentDbService : ExtractAzureDocumentDbService<StudentProfile>, IStudentExtractAzureDocumentDbService
    {
        public StudentExtractAzureDocumentDbService(ExtractDocumentDbServiceConfiguration configuration, IDiagnosticsTracingService diagnosticsTracingService) 
            : base(configuration, diagnosticsTracingService)
        {

        }

        public override int GetDocumentCount(DateTime watermarkDate)
        {
            return base.GetAllDocuments()
                .Count(x => x.TableName == SourceTableName && x.ModifiedDate > watermarkDate);
        }

        protected override IQueryable<StudentProfile> GetDocumentsQuery(DateTime watermarkDate)
        {
            return base.GetDocumentsWithContinuationToken()
                .Where(x => x.TableName == SourceTableName && x.ModifiedDate > watermarkDate)
                .OrderBy(x => x.ModifiedDate);
        }
    }
}
