using App.Core.Infrastructure.Services;
using App.Module3.Shared.Models.Messages.Extract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module3.Infrastructure.Services.Implementations.Extract
{
    public class ExtractServiceController : IExtractServiceController
    {
        private IRepositoryService _dbContext;
        private IUnitOfWorkService _unitOfWork;
        private IExtractAzureDocumentDbService _documentDBService;

        public ExtractServiceController(IRepositoryService dbContext, IUnitOfWorkService unitOfWork,
            IExtractAzureDocumentDbService documentDBService)
        {
            _dbContext = dbContext;
            _documentDBService = documentDBService;
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
                ProcessDestinationTable(tablename);
            }
        }


        public void ProcessDestinationTable(string name)
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
                    service = App.AppDependencyLocator.Current.GetInstance<BaseExtractService<SchoolProfiles>>();
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
                    service = App.AppDependencyLocator.Current.GetInstance<BaseExtractService<ReferenceAreaUnits>>();
                    break;
                case ExtractConstants._tableNameReferenceAuthorityType:
                    service = App.AppDependencyLocator.Current.GetInstance<BaseExtractService<ReferenceAuthorityType>>();
                    break;
                case ExtractConstants._tableNameReferenceCommunityBoards:
                    service = App.AppDependencyLocator.Current.GetInstance<BaseExtractService<ReferenceCommunityBoard>>();
                    break;
                case ExtractConstants._tableNameReferenceGeneralElectorate:
                    service = App.AppDependencyLocator.Current.GetInstance<BaseExtractService<ReferenceGeneralElectorate>>();
                    break;
                case ExtractConstants._tableNameReferenceMaoriElectorate:
                    service = App.AppDependencyLocator.Current.GetInstance<BaseExtractService<ReferenceMaoriElectorate>>();
                    break;
                case ExtractConstants._tableNameReferenceOrganisationStatus:
                    service = App.AppDependencyLocator.Current.GetInstance<BaseExtractService<ReferenceOrganisationStatus>>();
                    break;
                case ExtractConstants._tableNameReferenceOrganisationType:
                    service = App.AppDependencyLocator.Current.GetInstance<BaseExtractService<ReferenceOrganisationType>>();
                    break;
                case ExtractConstants._tableNameReferenceRegion:
                    service = App.AppDependencyLocator.Current.GetInstance<BaseExtractService<ReferenceRegion>>();
                    break;
                case ExtractConstants._tableNameReferenceRegionalCouncil:
                    service = App.AppDependencyLocator.Current.GetInstance<BaseExtractService<ReferenceRegionalCouncil>>();
                    break;
                case ExtractConstants._tableNameReferenceRelationshipType:
                    service = App.AppDependencyLocator.Current.GetInstance<BaseExtractService<ReferenceRelationshipType>>();
                    break;
                case ExtractConstants._tableNameReferenceSchoolClassification:
                    service = App.AppDependencyLocator.Current.GetInstance<BaseExtractService<ReferenceSchoolClassification>>();
                    break;
                case ExtractConstants._tableNameReferenceSchoolingGender:
                    service = App.AppDependencyLocator.Current.GetInstance<BaseExtractService<ReferenceSchoolingGender>>();
                    break;
                case ExtractConstants._tableNameReferenceSchoolYearLevel:
                    service = App.AppDependencyLocator.Current.GetInstance<BaseExtractService<ReferenceSchoolYearLevel>>();
                    break;
                case ExtractConstants._tableNameReferenceSpecialSchooling:
                    service = App.AppDependencyLocator.Current.GetInstance<BaseExtractService<ReferenceSpecialSchooling>>();
                    break;
                case ExtractConstants._tableNameReferenceTeacherEducation:
                    service = App.AppDependencyLocator.Current.GetInstance<BaseExtractService<ReferenceTeacherEducation>>();
                    break;
                case ExtractConstants._tableNameReferenceTerritorialAuthority:
                    service = App.AppDependencyLocator.Current.GetInstance<BaseExtractService<ReferenceTerritorialAuthority>>();
                    break;
                case ExtractConstants._tableNameReferenceUrbanArea:
                    service = App.AppDependencyLocator.Current.GetInstance<BaseExtractService<ReferenceUrbanArea>>();
                    break;
                case ExtractConstants._tableNameReferenceWard:
                    service = App.AppDependencyLocator.Current.GetInstance<BaseExtractService<ReferenceWard>>();
                    break;
            }
            service.Process();
        }


    }
}
