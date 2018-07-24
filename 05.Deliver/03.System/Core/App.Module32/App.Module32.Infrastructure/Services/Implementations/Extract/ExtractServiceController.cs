
using App.Core.Infrastructure.Services;
using System.Threading.Tasks;
using App.Core.Infrastructure.Initialization.DependencyResolution;
using App.Module32.Infrastructure.Services.Implementations.Extract.DataServices;
using App.Module32.Infrastructure.Services.Implementations.Extract.ReferenceServices;
using App.Module32.Infrastructure.Services.Interfaces.Extract;
using App.Module32.Shared.Models.Messages.Extract;

namespace App.Module32.Infrastructure.Services.Implementations.Extract
{
    public class ExtractServiceController : IExtractServiceController
    {
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;
        //private readonly IExtractRepositoryService _extractRepositoryService;


        public ExtractServiceController(IDiagnosticsTracingService diagnosticsTracingService)
        {
            _diagnosticsTracingService = diagnosticsTracingService;
            //_extractRepositoryService = extractRepositoryService;
        }


        public Task ProcessAllTablesAsync()
        {
            return Task.Run( () => { ProcessAllTables(); });
        }

        /// <summary>
        /// Will procress all Reference tables 
        /// Then any tables that have a references to the processed
        /// </summary>
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
                case ExtractConstants._tableNameStudentProfiles:
                    service = AppDependencyLocator.Current.GetInstance<StudentProfilesExtractService>();
                    break;
            }

            ProcessService(service);
        }

        private void ProcessService(IBaseExtractService service)
        {
            service?.Process();
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
            ProcessService(service);
        }


    }
}






