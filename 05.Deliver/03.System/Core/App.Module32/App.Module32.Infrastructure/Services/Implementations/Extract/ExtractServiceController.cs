
using App.Core.Infrastructure.Services;

using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Initialization.DependencyResolution;
using App.Module32.Infrastructure.Services;
using App.Module32.Infrastructure.Services.Implementations.Extract.DataServices;
using App.Module32.Infrastructure.Services.Implementations.Extract.ReferenceServices;
using App.Module32.Shared.Models.Messages.Extract;

namespace App.Module32.Infrastructure.Services.Implementations.Extract
{
    public class ExtractServiceController : IExtractServiceController
    {
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;
        private readonly IExtractRepositoryService _extractRepositoryService;


        public ExtractServiceController(IDiagnosticsTracingService diagnosticsTracingService, IExtractRepositoryService extractRepositoryService)
        {
            _diagnosticsTracingService = diagnosticsTracingService;
            _extractRepositoryService = extractRepositoryService;
        }


        public Task ProcessAllTablesAsync()
        {
            //Process Reference Tables first
            return Task.Run( () => { ProcessAllTables(); });

        }

        public void ProcessAllTables()
        {
            ProcessReferenceTables();
            ProcessDestinationTables();
        }

        public void ProcessReferenceTables()
        {
            
            foreach (var tablename in ExtractConstants.GetReferenceTableList())
            {
                ProcessReferenceTable(tablename);
            }
        }

        public void ProcessDestinationTables()
        {
            foreach (var tablename in ExtractConstants.GetDestinationTableList())
            {
                ProcessDataTable(tablename);
            }
        }


        public void ProcessDataTable(string name)
        {
            IBaseExtractService service = null;
            switch (name)
            {
                case ExtractConstants._tableNameSchoolProfiles:
                    service = AppDependencyLocator.Current.GetInstance<StudentProfilesExtractService>();
                    break;
            }
            service.Process(_extractRepositoryService);
        }


        public void ProcessReferenceTable(string name)
        {
            IBaseExtractService service = null;
            switch (name)
            {
                case ExtractConstants._tableNameSchoolProfiles:
                    service = AppDependencyLocator.Current.GetInstance<SchoolProfilesExtractService>();
                    break;
            }
            service.Process(_extractRepositoryService);
        }


    }
}






