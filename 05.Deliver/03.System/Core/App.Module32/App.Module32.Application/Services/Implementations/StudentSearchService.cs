using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Services;
using App.Module32.Infrastructure.Constants.Db;
using App.Module32.Shared.Models.Entities;

namespace App.Module32.Application.Services.Implementations
{
    public class StudentSearchService
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;
        private string _dbContextIdentifier = AppModuleDbContextNames.Default;

        public StudentSearchService(IDiagnosticsTracingService diagnosticsTracingService,
            IRepositoryService repositoryService
            )
        {
            _diagnosticsTracingService = diagnosticsTracingService;
            _repositoryService = repositoryService;
        }


        private IQueryable<EducationStudentProfile> InternalGetDbSet()
        {
            return this._repositoryService.GetQueryableSet<EducationStudentProfile>(this._dbContextIdentifier);
        }

    }
}
