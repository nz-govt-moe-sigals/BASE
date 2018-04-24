using App.Core.Infrastructure.Services;
using App.Module3.Shared.Models.Messages.Extract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Module3.Infrastructure.Services.Implementations.Extract.ReferenceServices;

namespace App.Module3.Infrastructure.Services.Implementations.Extract
{
    public class ExtractServiceController : IExtractServiceController
    {
        private IRepositoryService _dbContext;
        private IUnitOfWorkService _unitOfWork;
        private IExtractAzureDocumentDbService _documentDbService;

        public ExtractServiceController(IRepositoryService dbContext, IUnitOfWorkService unitOfWork,
            IExtractAzureDocumentDbService documentDbService)
        {
            _dbContext = dbContext;
            _documentDbService = documentDbService;
            _unitOfWork = unitOfWork;
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
                    service = App.AppDependencyLocator.Current.GetInstance<BaseExtractService<SchoolEnrol>>();
                    break;
                case ExtractConstants._tableNameSchoolLevelGender:
                    service = App.AppDependencyLocator.Current.GetInstance<BaseExtractService<SchoolLevelGender>>();
                    break;
                case ExtractConstants._tableNameSchoolProfiles:
                    service = App.AppDependencyLocator.Current.GetInstance<BaseExtractService<SchoolProfile>>();
                    break;
                case ExtractConstants._tableNameSchoolWGS:
                    service = App.AppDependencyLocator.Current.GetInstance<BaseExtractService<SchoolWGS>>();
                    break;
                case ExtractConstants._tableNameSummary:
                    service = App.AppDependencyLocator.Current.GetInstance<BaseExtractService<Summary>>();
                    break;
            }
            service.Process();
        }

        public void ProcessReferenceTable(string name)
        {
            IBaseExtractService service = null;
            switch (name)
            {
                case ExtractConstants._tableNameReferenceAreaUnits:
                    service = App.AppDependencyLocator.Current.GetInstance<ReferenceAreaUnitExtractService>();
                    break;
                case ExtractConstants._tableNameReferenceAuthorityType:
                    service = App.AppDependencyLocator.Current.GetInstance<ReferenceAuthorityTypeExtractService>();
                    break;
                case ExtractConstants._tableNameReferenceCommunityBoards:
                    service = App.AppDependencyLocator.Current.GetInstance<ReferenceCommunityBoardExtractService>();
                    break;
                case ExtractConstants._tableNameReferenceGeneralElectorate:
                    service = App.AppDependencyLocator.Current.GetInstance<ReferenceGeneralElectorateExtractService>();
                    break;
                case ExtractConstants._tableNameReferenceMaoriElectorate:
                    service = App.AppDependencyLocator.Current.GetInstance<ReferenceMaoriElectorateExtractService>();
                    break;
                case ExtractConstants._tableNameReferenceOrganisationStatus:
                    service = App.AppDependencyLocator.Current.GetInstance<ReferenceOrganisationStatusExtractService>();
                    break;
                case ExtractConstants._tableNameReferenceOrganisationType:
                    service = App.AppDependencyLocator.Current.GetInstance<ReferenceOrganisationTypeExtractService>();
                    break;
                case ExtractConstants._tableNameReferenceRegion:
                    service = App.AppDependencyLocator.Current.GetInstance<ReferenceRegionExtractService>();
                    break;
                case ExtractConstants._tableNameReferenceRegionalCouncil:
                    service = App.AppDependencyLocator.Current.GetInstance<ReferenceRegionalCouncilExtractService>();
                    break;
                case ExtractConstants._tableNameReferenceRelationshipType:
                    service = App.AppDependencyLocator.Current.GetInstance<ReferenceRelationshipTypeExtractService>();
                    break;
                case ExtractConstants._tableNameReferenceSchoolClassification:
                    service = App.AppDependencyLocator.Current.GetInstance<ReferenceSchoolClassificationExtractService>();
                    break;
                case ExtractConstants._tableNameReferenceSchoolingGender:
                    service = App.AppDependencyLocator.Current.GetInstance<ReferenceSchoolingGenderExtractService>();
                    break;
                case ExtractConstants._tableNameReferenceSchoolYearLevel:
                    service = App.AppDependencyLocator.Current.GetInstance<ReferenceSchoolYearLevelExtractService>();
                    break;
                case ExtractConstants._tableNameReferenceSpecialSchooling:
                    service = App.AppDependencyLocator.Current.GetInstance<ReferenceSpecialSchoolingExtractService>();
                    break;
                case ExtractConstants._tableNameReferenceTeacherEducation:
                    service = App.AppDependencyLocator.Current.GetInstance<ReferenceTeacherEducationExtractService>();
                    break;
                case ExtractConstants._tableNameReferenceTerritorialAuthority:
                    service = App.AppDependencyLocator.Current.GetInstance<ReferenceTerritorialAuthorityExtractService>();
                    break;
                case ExtractConstants._tableNameReferenceUrbanArea:
                    service = App.AppDependencyLocator.Current.GetInstance<ReferenceUrbanAreaExtractService>();
                    break;
                case ExtractConstants._tableNameReferenceWard:
                    service = App.AppDependencyLocator.Current.GetInstance<ReferenceWardExtractService>();
                    break;
            }
            service.Process();
        }


    }
}
