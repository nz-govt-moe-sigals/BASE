using App.Core.Infrastructure.Initialization.DependencyResolution;

namespace App.Module11.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Module11.Infrastructure.Initialization;
    using App.Module11.Infrastructure.Initialization.Db;
     
    public class AppModuleDbModelBuilderOrchestrator: IHasModuleSpecificIdentifier
    {
        // Azure DataFactory Import:
        private readonly AppModuleDbContextModelBuilderDefineExtractWatermark _appModuleDbContextModelBuilderDefineExtractWatermark;
        // Reference data:
        private readonly AppModuleDbContextModelBuilderDefineAreaUnit _appModuleDbContextModelBuilderDefineAreaUnit;
        private readonly AppModuleDbContextModelBuilderDefineAuthorityType _appModuleDbContextModelBuilderDefineAuthorityType;
        private readonly AppModuleDbContextModelBuilderDefineCommunityBoard _appModuleDbContextModelBuilderDefineCommunityBoard;
        private readonly AppModuleDbContextModelBuilderDefineGeneralElectorate _appModuleDbContextModelBuilderDefineGeneralElectorate;
        private readonly AppModuleDbContextModelBuilderDefineMaoriElectorate _appModuleDbContextModelBuilderDefineMaoriElectorate;
        private readonly AppModuleDbContextModelBuilderDefineOrganisationStatus _appModuleDbContextModelBuilderDefineOrganisationStatus;
        private readonly AppModuleDbContextModelBuilderDefineOrganisationType _appModuleDbContextModelBuilderDefineOrganisationType;
        private readonly AppModuleDbContextModelBuilderDefineRegion _appModuleDbContextModelBuilderDefineRegion;
        private readonly AppModuleDbContextModelBuilderDefineRegionalCouncil _appModuleDbContextModelBuilderDefineRegionalCouncil;
        private readonly AppModuleDbContextModelBuilderDefineRelationshipType _appModuleDbContextModelBuilderDefineRelationshipType;
        private readonly AppModuleDbContextModelBuilderDefineSchoolClassification _appModuleDbContextModelBuilderDefineSchoolClassification;
        private readonly AppModuleDbContextModelBuilderDefineEducationProviderGender _appModuleDbContextModelBuilderDefineSchoolGender;
        private readonly AppModuleDbContextModelBuilderDefineSchoolYearLevel _appModuleDbContextModelBuilderDefineSchoolYearLevel;
        private readonly AppModuleDbContextModelBuilderDefineSpecialSchooling _appModuleDbContextModelBuilderDefineSpecialSchooling;
        private readonly AppModuleDbContextModelBuilderDefineTeacherEducation _appModuleDbContextModelBuilderDefineTeacherEducation;
        private readonly AppModuleDbContextModelBuilderDefineTerritorialAuthority _appModuleDbContextModelBuilderDefineTerritorialAuthority;
        private readonly AppModuleDbContextModelBuilderDefineUrbanArea _appModuleDbContextModelBuilderDefineUrbanArea;
        private readonly AppModuleDbContextModelBuilderDefineWard _appModuleDbContextModelBuilderDefineWard;
        private readonly AppModuleDbContextModelBuilderDefineEducationProviderEnrolmentCount _appModuleDbContextModelBuilderDefineEducationProviderEnrolmentCount;
        private readonly AppModuleDbContextModelBuilderDefineEducationProviderLevelGender _appModuleDbContextModelBuilderDefineEducationProviderLevelGender;
        private readonly AppModuleDbContextModelBuilderDefineEducationProvider _appModuleDbContextModelBuilderDefineSchoolProfile;
        private readonly AppModuleDbContextModelBuilderDefineEducationProvideLocation _appModuleDbContextModelBuilderDefineSchoolWgs;


        public AppModuleDbModelBuilderOrchestrator(
            //Reference data:
            AppModuleDbContextModelBuilderDefineAreaUnit appModuleDbContextModelBuilderDefineAreaUnit,
            AppModuleDbContextModelBuilderDefineAuthorityType appModuleDbContextModelBuilderDefineAuthorityType,
            AppModuleDbContextModelBuilderDefineCommunityBoard appModuleDbContextModelBuilderDefineCommunityBoard,
            AppModuleDbContextModelBuilderDefineGeneralElectorate appModuleDbContextModelBuilderDefineGeneralElectorate,
            AppModuleDbContextModelBuilderDefineMaoriElectorate appModuleDbContextModelBuilderDefineMaoriElectorate,
            AppModuleDbContextModelBuilderDefineOrganisationStatus appModuleDbContextModelBuilderDefineOrganisationStatus,
            AppModuleDbContextModelBuilderDefineOrganisationType appModuleDbContextModelBuilderDefineOrganisationType,
            AppModuleDbContextModelBuilderDefineRegion appModuleDbContextModelBuilderDefineRegion,
            AppModuleDbContextModelBuilderDefineRegionalCouncil appModuleDbContextModelBuilderDefineRegionalCouncil,
            AppModuleDbContextModelBuilderDefineRelationshipType appModuleDbContextModelBuilderDefineRelationshipType,
            AppModuleDbContextModelBuilderDefineSchoolClassification appModuleDbContextModelBuilderDefineSchoolClassification,
            AppModuleDbContextModelBuilderDefineEducationProviderGender appModuleDbContextModelBuilderDefineSchoolGender,
            AppModuleDbContextModelBuilderDefineSchoolYearLevel appModuleDbContextModelBuilderDefineSchoolYearLevel,
            AppModuleDbContextModelBuilderDefineSpecialSchooling appModuleDbContextModelBuilderDefineSpecialSchooling,
            AppModuleDbContextModelBuilderDefineTeacherEducation appModuleDbContextModelBuilderDefineTeacherEducation,
            AppModuleDbContextModelBuilderDefineTerritorialAuthority appModuleDbContextModelBuilderDefineTerritorialAuthority,
            AppModuleDbContextModelBuilderDefineUrbanArea appModuleDbContextModelBuilderDefineUrbanArea,
            AppModuleDbContextModelBuilderDefineWard appModuleDbContextModelBuilderDefineWard,
            // objects:

                AppModuleDbContextModelBuilderDefineEducationProviderEnrolmentCount appModuleDbContextModelBuilderDefineEducationProviderEnrolmentCount,
                AppModuleDbContextModelBuilderDefineEducationProviderLevelGender appModuleDbContextModelBuilderDefineEducationProviderLevelGender,
                AppModuleDbContextModelBuilderDefineEducationProvider appModuleDbContextModelBuilderDefineSchoolProfile,
                AppModuleDbContextModelBuilderDefineEducationProvideLocation appModuleDbContextModelBuilderDefineSchoolWgs,
            AppModuleDbContextModelBuilderDefineExtractWatermark  appModuleDbContextModelBuilderDefineExtractWatermark 

            )
        {
            // Reference:
            this._appModuleDbContextModelBuilderDefineAreaUnit = appModuleDbContextModelBuilderDefineAreaUnit;
            this._appModuleDbContextModelBuilderDefineAuthorityType = appModuleDbContextModelBuilderDefineAuthorityType;
            this._appModuleDbContextModelBuilderDefineCommunityBoard = appModuleDbContextModelBuilderDefineCommunityBoard;
            this._appModuleDbContextModelBuilderDefineGeneralElectorate = appModuleDbContextModelBuilderDefineGeneralElectorate;
            this._appModuleDbContextModelBuilderDefineMaoriElectorate = appModuleDbContextModelBuilderDefineMaoriElectorate;
            this._appModuleDbContextModelBuilderDefineOrganisationStatus = appModuleDbContextModelBuilderDefineOrganisationStatus;
            this._appModuleDbContextModelBuilderDefineOrganisationType = appModuleDbContextModelBuilderDefineOrganisationType;
            this._appModuleDbContextModelBuilderDefineRegion = appModuleDbContextModelBuilderDefineRegion;
            this._appModuleDbContextModelBuilderDefineRegionalCouncil = appModuleDbContextModelBuilderDefineRegionalCouncil;
            this._appModuleDbContextModelBuilderDefineRelationshipType = appModuleDbContextModelBuilderDefineRelationshipType;
            this._appModuleDbContextModelBuilderDefineSchoolClassification = appModuleDbContextModelBuilderDefineSchoolClassification;
            this._appModuleDbContextModelBuilderDefineSchoolGender = appModuleDbContextModelBuilderDefineSchoolGender;
            this._appModuleDbContextModelBuilderDefineSchoolYearLevel = appModuleDbContextModelBuilderDefineSchoolYearLevel;
            this._appModuleDbContextModelBuilderDefineSpecialSchooling = appModuleDbContextModelBuilderDefineSpecialSchooling;
            this._appModuleDbContextModelBuilderDefineTeacherEducation = appModuleDbContextModelBuilderDefineTeacherEducation;
            this._appModuleDbContextModelBuilderDefineTerritorialAuthority = appModuleDbContextModelBuilderDefineTerritorialAuthority;
            this._appModuleDbContextModelBuilderDefineUrbanArea = appModuleDbContextModelBuilderDefineUrbanArea;
            this._appModuleDbContextModelBuilderDefineWard = appModuleDbContextModelBuilderDefineWard;
            //Data:
            this._appModuleDbContextModelBuilderDefineEducationProviderEnrolmentCount = appModuleDbContextModelBuilderDefineEducationProviderEnrolmentCount;
            this._appModuleDbContextModelBuilderDefineEducationProviderLevelGender = appModuleDbContextModelBuilderDefineEducationProviderLevelGender;
            this._appModuleDbContextModelBuilderDefineSchoolProfile = appModuleDbContextModelBuilderDefineSchoolProfile;
            this._appModuleDbContextModelBuilderDefineSchoolWgs = appModuleDbContextModelBuilderDefineSchoolWgs;
            // Peter:
            this._appModuleDbContextModelBuilderDefineExtractWatermark = appModuleDbContextModelBuilderDefineExtractWatermark;
        }


        public void Initialize(DbModelBuilder modelBuilder)
        {
            //if (!PowershellServiceLocatorConfig.Activated)
            //{
                DefineByReflection(modelBuilder);
            //}
            //else
            //{
            //    //Reflection does not work under Powershell, so:
            //DefineByHand(modelBuilder);
            //}

            // Or if convention/reflection/magic is not your cup of tea, 
            // you can do it the old way, invoke *n* methods to initialize 
            // the Schema of the DbModelBuilder for a DbContext: 
            // new DbContextModeBuilderDefineExample().Define(modelBuilder);
            //etc...
        }

        private void DefineByReflection(DbModelBuilder modelBuilder)
        {
            // You can initialize manually or by Convention over Configuration
            // using a combination of common interface and reflection.

            AppDependencyLocator.Current.GetAllInstances<IHasAppModuleDbContextModelBuilderInitializer>()
                .ForEach(x => x.Define(modelBuilder));
        }

        //private void DefineByHand(DbModelBuilder modelBuilder)
        //{
        //    //Azure Data Factory Import:
        //    _appModuleDbContextModelBuilderDefineExtractWatermark.DefineTable(modelBuilder);
        //    // Reference Data:
        //    _appModuleDbContextModelBuilderDefineAreaUnit.Define(modelBuilder);
        //    _appModuleDbContextModelBuilderDefineAuthorityType.Define(modelBuilder);
        //    _appModuleDbContextModelBuilderDefineCommunityBoard.Define(modelBuilder);
        //    _appModuleDbContextModelBuilderDefineGeneralElectorate.Define(modelBuilder);
        //    _appModuleDbContextModelBuilderDefineMaoriElectorate.Define(modelBuilder);
        //    _appModuleDbContextModelBuilderDefineOrganisationStatus.Define(modelBuilder);
        //    _appModuleDbContextModelBuilderDefineOrganisationType.Define(modelBuilder);
        //    _appModuleDbContextModelBuilderDefineRegion.Define(modelBuilder);
        //    _appModuleDbContextModelBuilderDefineRegionalCouncil.Define(modelBuilder);
        //    _appModuleDbContextModelBuilderDefineRelationshipType.Define(modelBuilder);
        //    _appModuleDbContextModelBuilderDefineSchoolClassification.Define(modelBuilder);
        //    _appModuleDbContextModelBuilderDefineSchoolGender.Define(modelBuilder);
        //    _appModuleDbContextModelBuilderDefineSchoolYearLevel.Define(modelBuilder);
        //    _appModuleDbContextModelBuilderDefineSpecialSchooling.Define(modelBuilder);
        //    _appModuleDbContextModelBuilderDefineTeacherEducation.Define(modelBuilder);
        //    _appModuleDbContextModelBuilderDefineTerritorialAuthority.Define(modelBuilder);
        //    _appModuleDbContextModelBuilderDefineUrbanArea.Define(modelBuilder);
        //    _appModuleDbContextModelBuilderDefineWard.Define(modelBuilder);
        //    // Data:
        //    _appModuleDbContextModelBuilderDefineSchoolWgs.Define(modelBuilder);
        //    _appModuleDbContextModelBuilderDefineEducationProviderEnrolmentCount.Define(modelBuilder);
        //    _appModuleDbContextModelBuilderDefineEducationProviderLevelGender.Define(modelBuilder);
        //    _appModuleDbContextModelBuilderDefineSchoolProfile.Define(modelBuilder);

        //}
    }
}