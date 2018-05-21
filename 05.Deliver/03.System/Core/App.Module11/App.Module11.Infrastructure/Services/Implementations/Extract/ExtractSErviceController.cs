
using App.Core.Infrastructure.Services;
using App.Module11.Shared.Models.Messages.Extract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Initialization.DependencyResolution;
using App.Module11.Infrastructure.Services.Implementations.Extract.DataServices;
using App.Module11.Infrastructure.Services.Implementations.Extract.ReferenceServices;

namespace App.Module11.Infrastructure.Services.Implementations.Extract
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

        public void ProcessAllTables()
        {
            //Process Reference Tables first
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
                case ExtractConstants._tableNameSchoolEnrol:
                    service = AppDependencyLocator.Current.GetInstance<SchoolEnrolExtractService>();
                    break;
                case ExtractConstants._tableNameSchoolLevelGender:
                    service = AppDependencyLocator.Current.GetInstance<SchoolLevelGenderExtractService>();
                    break;
                case ExtractConstants._tableNameSchoolProfiles:
                    service = AppDependencyLocator.Current.GetInstance<SchoolProfilesExtractService>();
                    break;
                case ExtractConstants._tableNameSchoolWGS:
                    service = AppDependencyLocator.Current.GetInstance<SchoolWGSExtractService>();
                    break;
                //case ExtractConstants._tableNameSummary:
                //    service = App.AppDependencyLocator.Current.GetInstance<BaseExtractService<Summary>>();
                //    break;
            }
            service.Process(_extractRepositoryService);
        }

        public void ProcessReferenceTable(string name)
        {
            IBaseExtractService service = null;
            switch (name)
            {
                case ExtractConstants._tableNameReferenceAreaUnits:
                    service = AppDependencyLocator.Current.GetInstance<ReferenceAreaUnitExtractService>();
                    break;
                case ExtractConstants._tableNameReferenceAuthorityType:
                    service = AppDependencyLocator.Current.GetInstance<ReferenceAuthorityTypeExtractService>();
                    break;
                case ExtractConstants._tableNameReferenceCommunityBoards:
                    service = AppDependencyLocator.Current.GetInstance<ReferenceCommunityBoardExtractService>();
                    break;
                case ExtractConstants._tableNameReferenceGeneralElectorate:
                    service = AppDependencyLocator.Current.GetInstance<ReferenceGeneralElectorateExtractService>();
                    break;
                case ExtractConstants._tableNameReferenceMaoriElectorate:
                    service = AppDependencyLocator.Current.GetInstance<ReferenceMaoriElectorateExtractService>();
                    break;
                case ExtractConstants._tableNameReferenceOrganisationStatus:
                    service = AppDependencyLocator.Current.GetInstance<ReferenceOrganisationStatusExtractService>();
                    break;
                case ExtractConstants._tableNameReferenceOrganisationType:
                    service = AppDependencyLocator.Current.GetInstance<ReferenceOrganisationTypeExtractService>();
                    break;
                case ExtractConstants._tableNameReferenceRegion:
                    service = AppDependencyLocator.Current.GetInstance<ReferenceRegionExtractService>();
                    break;
                case ExtractConstants._tableNameReferenceRegionalCouncil:
                    service = AppDependencyLocator.Current.GetInstance<ReferenceRegionalCouncilExtractService>();
                    break;
                case ExtractConstants._tableNameReferenceRelationshipType:
                    service = AppDependencyLocator.Current.GetInstance<ReferenceRelationshipTypeExtractService>();
                    break;
                case ExtractConstants._tableNameReferenceSchoolClassification:
                    service = AppDependencyLocator.Current.GetInstance<ReferenceSchoolClassificationExtractService>();
                    break;
                case ExtractConstants._tableNameReferenceSchoolingGender:
                    service = AppDependencyLocator.Current.GetInstance<ReferenceSchoolingGenderExtractService>();
                    break;
                case ExtractConstants._tableNameReferenceSchoolYearLevel:
                    service = AppDependencyLocator.Current.GetInstance<ReferenceSchoolYearLevelExtractService>();
                    break;
                case ExtractConstants._tableNameReferenceSpecialSchooling:
                    service = AppDependencyLocator.Current.GetInstance<ReferenceSpecialSchoolingExtractService>();
                    break;
                case ExtractConstants._tableNameReferenceTeacherEducation:
                    service = AppDependencyLocator.Current.GetInstance<ReferenceTeacherEducationExtractService>();
                    break;
                case ExtractConstants._tableNameReferenceTerritorialAuthority:
                    service = AppDependencyLocator.Current.GetInstance<ReferenceTerritorialAuthorityExtractService>();
                    break;
                case ExtractConstants._tableNameReferenceUrbanArea:
                    service = AppDependencyLocator.Current.GetInstance<ReferenceUrbanAreaExtractService>();
                    break;
                case ExtractConstants._tableNameReferenceWard:
                    service = AppDependencyLocator.Current.GetInstance<ReferenceWardExtractService>();
                    break;
            }
            service.Process(_extractRepositoryService);
        }


    }
}

