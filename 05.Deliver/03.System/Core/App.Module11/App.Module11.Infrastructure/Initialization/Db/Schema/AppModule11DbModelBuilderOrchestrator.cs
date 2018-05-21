using App.Core.Infrastructure.Initialization.DependencyResolution;

namespace App.Module11.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Module11.Infrastructure.Initialization;
    using App.Module11.Infrastructure.Initialization.Db;

    public class AppModule11DbModelBuilderOrchestrator
    {
        // Azure DataFactory Import:
        private readonly AppModule11DbContextModelBuilderDefineExtractWatermark _appModule11DbContextModelBuilderDefineExtractWatermark;
        // Reference data:
        private readonly AppModule11DbContextModelBuilderDefineAreaUnit _appModule11DbContextModelBuilderDefineAreaUnit;
        private readonly AppModule11DbContextModelBuilderDefineAuthorityType _appModule11DbContextModelBuilderDefineAuthorityType;
        private readonly AppModule11DbContextModelBuilderDefineCommunityBoard _appModule11DbContextModelBuilderDefineCommunityBoard;
        private readonly AppModule11DbContextModelBuilderDefineGeneralElectorate _appModule11DbContextModelBuilderDefineGeneralElectorate;
        private readonly AppModule11DbContextModelBuilderDefineMaoriElectorate _appModule11DbContextModelBuilderDefineMaoriElectorate;
        private readonly AppModule11DbContextModelBuilderDefineOrganisationStatus _appModule11DbContextModelBuilderDefineOrganisationStatus;
        private readonly AppModule11DbContextModelBuilderDefineOrganisationType _appModule11DbContextModelBuilderDefineOrganisationType;
        private readonly AppModule11DbContextModelBuilderDefineRegion _appModule11DbContextModelBuilderDefineRegion;
        private readonly AppModule11DbContextModelBuilderDefineRegionalCouncil _appModule11DbContextModelBuilderDefineRegionalCouncil;
        private readonly AppModule11DbContextModelBuilderDefineRelationshipType _appModule11DbContextModelBuilderDefineRelationshipType;
        private readonly AppModule11DbContextModelBuilderDefineSchoolClassification _appModule11DbContextModelBuilderDefineSchoolClassification;
        private readonly AppModule11DbContextModelBuilderDefineEducationProviderGender _appModule11DbContextModelBuilderDefineSchoolGender;
        private readonly AppModule11DbContextModelBuilderDefineSchoolYearLevel _appModule11DbContextModelBuilderDefineSchoolYearLevel;
        private readonly AppModule11DbContextModelBuilderDefineSpecialSchooling _appModule11DbContextModelBuilderDefineSpecialSchooling;
        private readonly AppModule11DbContextModelBuilderDefineTeacherEducation _appModule11DbContextModelBuilderDefineTeacherEducation;
        private readonly AppModule11DbContextModelBuilderDefineTerritorialAuthority _appModule11DbContextModelBuilderDefineTerritorialAuthority;
        private readonly AppModule11DbContextModelBuilderDefineUrbanArea _appModule11DbContextModelBuilderDefineUrbanArea;
        private readonly AppModule11DbContextModelBuilderDefineWard _appModule11DbContextModelBuilderDefineWard;
        private readonly AppModule11DbContextModelBuilderDefineEducationProviderEnrolmentCount _appModule11DbContextModelBuilderDefineEducationProviderEnrolmentCount;
        private readonly AppModule11DbContextModelBuilderDefineEducationProviderLevelGender _appModule11DbContextModelBuilderDefineEducationProviderLevelGender;
        private readonly AppModule11DbContextModelBuilderDefineEducationProvider _appModule11DbContextModelBuilderDefineSchoolProfile;
        private readonly AppModule11DbContextModelBuilderDefineEducationProvideLocation _appModule11DbContextModelBuilderDefineSchoolWgs;


        public AppModule11DbModelBuilderOrchestrator(
            //Reference data:
            AppModule11DbContextModelBuilderDefineAreaUnit appModule11DbContextModelBuilderDefineAreaUnit,
            AppModule11DbContextModelBuilderDefineAuthorityType appModule11DbContextModelBuilderDefineAuthorityType,
            AppModule11DbContextModelBuilderDefineCommunityBoard appModule11DbContextModelBuilderDefineCommunityBoard,
            AppModule11DbContextModelBuilderDefineGeneralElectorate appModule11DbContextModelBuilderDefineGeneralElectorate,
            AppModule11DbContextModelBuilderDefineMaoriElectorate appModule11DbContextModelBuilderDefineMaoriElectorate,
            AppModule11DbContextModelBuilderDefineOrganisationStatus appModule11DbContextModelBuilderDefineOrganisationStatus,
            AppModule11DbContextModelBuilderDefineOrganisationType appModule11DbContextModelBuilderDefineOrganisationType,
            AppModule11DbContextModelBuilderDefineRegion appModule11DbContextModelBuilderDefineRegion,
            AppModule11DbContextModelBuilderDefineRegionalCouncil appModule11DbContextModelBuilderDefineRegionalCouncil,
            AppModule11DbContextModelBuilderDefineRelationshipType appModule11DbContextModelBuilderDefineRelationshipType,
            AppModule11DbContextModelBuilderDefineSchoolClassification appModule11DbContextModelBuilderDefineSchoolClassification,
            AppModule11DbContextModelBuilderDefineEducationProviderGender appModule11DbContextModelBuilderDefineSchoolGender,
            AppModule11DbContextModelBuilderDefineSchoolYearLevel appModule11DbContextModelBuilderDefineSchoolYearLevel,
            AppModule11DbContextModelBuilderDefineSpecialSchooling appModule11DbContextModelBuilderDefineSpecialSchooling,
            AppModule11DbContextModelBuilderDefineTeacherEducation appModule11DbContextModelBuilderDefineTeacherEducation,
            AppModule11DbContextModelBuilderDefineTerritorialAuthority appModule11DbContextModelBuilderDefineTerritorialAuthority,
            AppModule11DbContextModelBuilderDefineUrbanArea appModule11DbContextModelBuilderDefineUrbanArea,
            AppModule11DbContextModelBuilderDefineWard appModule11DbContextModelBuilderDefineWard,
            // objects:

                AppModule11DbContextModelBuilderDefineEducationProviderEnrolmentCount appModule11DbContextModelBuilderDefineEducationProviderEnrolmentCount,
                AppModule11DbContextModelBuilderDefineEducationProviderLevelGender appModule11DbContextModelBuilderDefineEducationProviderLevelGender,
                AppModule11DbContextModelBuilderDefineEducationProvider appModule11DbContextModelBuilderDefineSchoolProfile,
                AppModule11DbContextModelBuilderDefineEducationProvideLocation appModule11DbContextModelBuilderDefineSchoolWgs,
            AppModule11DbContextModelBuilderDefineExtractWatermark  appModule11DbContextModelBuilderDefineExtractWatermark 

            )
        {
            // Reference:
            this._appModule11DbContextModelBuilderDefineAreaUnit = appModule11DbContextModelBuilderDefineAreaUnit;
            this._appModule11DbContextModelBuilderDefineAuthorityType = appModule11DbContextModelBuilderDefineAuthorityType;
            this._appModule11DbContextModelBuilderDefineCommunityBoard = appModule11DbContextModelBuilderDefineCommunityBoard;
            this._appModule11DbContextModelBuilderDefineGeneralElectorate = appModule11DbContextModelBuilderDefineGeneralElectorate;
            this._appModule11DbContextModelBuilderDefineMaoriElectorate = appModule11DbContextModelBuilderDefineMaoriElectorate;
            this._appModule11DbContextModelBuilderDefineOrganisationStatus = appModule11DbContextModelBuilderDefineOrganisationStatus;
            this._appModule11DbContextModelBuilderDefineOrganisationType = appModule11DbContextModelBuilderDefineOrganisationType;
            this._appModule11DbContextModelBuilderDefineRegion = appModule11DbContextModelBuilderDefineRegion;
            this._appModule11DbContextModelBuilderDefineRegionalCouncil = appModule11DbContextModelBuilderDefineRegionalCouncil;
            this._appModule11DbContextModelBuilderDefineRelationshipType = appModule11DbContextModelBuilderDefineRelationshipType;
            this._appModule11DbContextModelBuilderDefineSchoolClassification = appModule11DbContextModelBuilderDefineSchoolClassification;
            this._appModule11DbContextModelBuilderDefineSchoolGender = appModule11DbContextModelBuilderDefineSchoolGender;
            this._appModule11DbContextModelBuilderDefineSchoolYearLevel = appModule11DbContextModelBuilderDefineSchoolYearLevel;
            this._appModule11DbContextModelBuilderDefineSpecialSchooling = appModule11DbContextModelBuilderDefineSpecialSchooling;
            this._appModule11DbContextModelBuilderDefineTeacherEducation = appModule11DbContextModelBuilderDefineTeacherEducation;
            this._appModule11DbContextModelBuilderDefineTerritorialAuthority = appModule11DbContextModelBuilderDefineTerritorialAuthority;
            this._appModule11DbContextModelBuilderDefineUrbanArea = appModule11DbContextModelBuilderDefineUrbanArea;
            this._appModule11DbContextModelBuilderDefineWard = appModule11DbContextModelBuilderDefineWard;
            //Data:
            this._appModule11DbContextModelBuilderDefineEducationProviderEnrolmentCount = appModule11DbContextModelBuilderDefineEducationProviderEnrolmentCount;
            this._appModule11DbContextModelBuilderDefineEducationProviderLevelGender = appModule11DbContextModelBuilderDefineEducationProviderLevelGender;
            this._appModule11DbContextModelBuilderDefineSchoolProfile = appModule11DbContextModelBuilderDefineSchoolProfile;
            this._appModule11DbContextModelBuilderDefineSchoolWgs = appModule11DbContextModelBuilderDefineSchoolWgs;
            // Peter:
            this._appModule11DbContextModelBuilderDefineExtractWatermark = appModule11DbContextModelBuilderDefineExtractWatermark;
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

            AppDependencyLocator.Current.GetAllInstances<IHasAppModule11DbContextModelBuilderInitializer>()
                .ForEach(x => x.Define(modelBuilder));
        }

        //private void DefineByHand(DbModelBuilder modelBuilder)
        //{
        //    //Azure Data Factory Import:
        //    _appModule11DbContextModelBuilderDefineExtractWatermark.DefineTable(modelBuilder);
        //    // Reference Data:
        //    _appModule11DbContextModelBuilderDefineAreaUnit.Define(modelBuilder);
        //    _appModule11DbContextModelBuilderDefineAuthorityType.Define(modelBuilder);
        //    _appModule11DbContextModelBuilderDefineCommunityBoard.Define(modelBuilder);
        //    _appModule11DbContextModelBuilderDefineGeneralElectorate.Define(modelBuilder);
        //    _appModule11DbContextModelBuilderDefineMaoriElectorate.Define(modelBuilder);
        //    _appModule11DbContextModelBuilderDefineOrganisationStatus.Define(modelBuilder);
        //    _appModule11DbContextModelBuilderDefineOrganisationType.Define(modelBuilder);
        //    _appModule11DbContextModelBuilderDefineRegion.Define(modelBuilder);
        //    _appModule11DbContextModelBuilderDefineRegionalCouncil.Define(modelBuilder);
        //    _appModule11DbContextModelBuilderDefineRelationshipType.Define(modelBuilder);
        //    _appModule11DbContextModelBuilderDefineSchoolClassification.Define(modelBuilder);
        //    _appModule11DbContextModelBuilderDefineSchoolGender.Define(modelBuilder);
        //    _appModule11DbContextModelBuilderDefineSchoolYearLevel.Define(modelBuilder);
        //    _appModule11DbContextModelBuilderDefineSpecialSchooling.Define(modelBuilder);
        //    _appModule11DbContextModelBuilderDefineTeacherEducation.Define(modelBuilder);
        //    _appModule11DbContextModelBuilderDefineTerritorialAuthority.Define(modelBuilder);
        //    _appModule11DbContextModelBuilderDefineUrbanArea.Define(modelBuilder);
        //    _appModule11DbContextModelBuilderDefineWard.Define(modelBuilder);
        //    // Data:
        //    _appModule11DbContextModelBuilderDefineSchoolWgs.Define(modelBuilder);
        //    _appModule11DbContextModelBuilderDefineEducationProviderEnrolmentCount.Define(modelBuilder);
        //    _appModule11DbContextModelBuilderDefineEducationProviderLevelGender.Define(modelBuilder);
        //    _appModule11DbContextModelBuilderDefineSchoolProfile.Define(modelBuilder);

        //}
    }
}