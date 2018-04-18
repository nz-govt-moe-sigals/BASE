namespace App.Module3.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Module3.DbContextModelBuilder;
    using App.Module3.Infrastructure.Initialization;
    using App.Module3.Infrastructure.Initialization.Db;

    public class AppModule3DbModelBuilderOrchestrator
    {
        // Reference data:
        private readonly AppModule3DbContextModelBuilderDefineAreaUnit _appModule3DbContextModelBuilderDefineAreaUnit;
        private readonly AppModule3DbContextModelBuilderDefineAuthorityType _appModule3DbContextModelBuilderDefineAuthorityType;
        private readonly AppModule3DbContextModelBuilderDefineCommunityBoard _appModule3DbContextModelBuilderDefineCommunityBoard;
        private readonly AppModule3DbContextModelBuilderDefineGeneralElectorate _appModule3DbContextModelBuilderDefineGeneralElectorate;
        private readonly AppModule3DbContextModelBuilderDefineMaoriElectorate _appModule3DbContextModelBuilderDefineMaoriElectorate;
        private readonly AppModule3DbContextModelBuilderDefineOrganisationStatus _appModule3DbContextModelBuilderDefineOrganisationStatus;
        private readonly AppModule3DbContextModelBuilderDefineOrganisationType _appModule3DbContextModelBuilderDefineOrganisationType;
        private readonly AppModule3DbContextModelBuilderDefineRegion _appModule3DbContextModelBuilderDefineRegion;
        private readonly AppModule3DbContextModelBuilderDefineRegionalCouncil _appModule3DbContextModelBuilderDefineRegionalCouncil;
        private readonly AppModule3DbContextModelBuilderDefineRelationshipType _appModule3DbContextModelBuilderDefineRelationshipType;
        private readonly AppModule3DbContextModelBuilderDefineSchoolClassification _appModule3DbContextModelBuilderDefineSchoolClassification;
        private readonly AppModule3DbContextModelBuilderDefineEducationProviderGender _appModule3DbContextModelBuilderDefineSchoolGender;
        private readonly AppModule3DbContextModelBuilderDefineSchoolYearLevel _appModule3DbContextModelBuilderDefineSchoolYearLevel;
        private readonly AppModule3DbContextModelBuilderDefineSpecialSchooling _appModule3DbContextModelBuilderDefineSpecialSchooling;
        private readonly AppModule3DbContextModelBuilderDefineTeacherEducation _appModule3DbContextModelBuilderDefineTeacherEducation;
        private readonly AppModule3DbContextModelBuilderDefineTerritorialAuthority _appModule3DbContextModelBuilderDefineTerritorialAuthority;
        private readonly AppModule3DbContextModelBuilderDefineUrbanArea _appModule3DbContextModelBuilderDefineUrbanArea;
        private readonly AppModule3DbContextModelBuilderDefineWard _appModule3DbContextModelBuilderDefineWard;
        private readonly AppModule3DbContextModelBuilderDefineSchoolEnrol _appModule3DbContextModelBuilderDefineSchoolEnrol;
        private readonly AppModule3DbContextModelBuilderDefineSchoolLevelGender _appModule3DbContextModelBuilderDefineSchoolLevelGender;
        private readonly AppModule3DbContextModelBuilderDefineEducationProviderProfile _appModule3DbContextModelBuilderDefineSchoolProfile;
        private readonly AppModule3DbContextModelBuilderDefineEducationProvideLocation _appModule3DbContextModelBuilderDefineSchoolWgs;

        public AppModule3DbModelBuilderOrchestrator(
            //Reference data:
            AppModule3DbContextModelBuilderDefineAreaUnit appModule3DbContextModelBuilderDefineAreaUnit,
            AppModule3DbContextModelBuilderDefineAuthorityType appModule3DbContextModelBuilderDefineAuthorityType,
            AppModule3DbContextModelBuilderDefineCommunityBoard appModule3DbContextModelBuilderDefineCommunityBoard,
            AppModule3DbContextModelBuilderDefineGeneralElectorate appModule3DbContextModelBuilderDefineGeneralElectorate,
            AppModule3DbContextModelBuilderDefineMaoriElectorate appModule3DbContextModelBuilderDefineMaoriElectorate,
            AppModule3DbContextModelBuilderDefineOrganisationStatus appModule3DbContextModelBuilderDefineOrganisationStatus,
            AppModule3DbContextModelBuilderDefineOrganisationType appModule3DbContextModelBuilderDefineOrganisationType,
            AppModule3DbContextModelBuilderDefineRegion appModule3DbContextModelBuilderDefineRegion,
            AppModule3DbContextModelBuilderDefineRegionalCouncil appModule3DbContextModelBuilderDefineRegionalCouncil,
            AppModule3DbContextModelBuilderDefineRelationshipType appModule3DbContextModelBuilderDefineRelationshipType,
            AppModule3DbContextModelBuilderDefineSchoolClassification appModule3DbContextModelBuilderDefineSchoolClassification,
            AppModule3DbContextModelBuilderDefineEducationProviderGender appModule3DbContextModelBuilderDefineSchoolGender,
            AppModule3DbContextModelBuilderDefineSchoolYearLevel appModule3DbContextModelBuilderDefineSchoolYearLevel,
            AppModule3DbContextModelBuilderDefineSpecialSchooling appModule3DbContextModelBuilderDefineSpecialSchooling,
            AppModule3DbContextModelBuilderDefineTeacherEducation appModule3DbContextModelBuilderDefineTeacherEducation,
            AppModule3DbContextModelBuilderDefineTerritorialAuthority appModule3DbContextModelBuilderDefineTerritorialAuthority,
            AppModule3DbContextModelBuilderDefineUrbanArea appModule3DbContextModelBuilderDefineUrbanArea,
            AppModule3DbContextModelBuilderDefineWard appModule3DbContextModelBuilderDefineWard,
            // objects:
                AppModule3DbContextModelBuilderDefineSchoolEnrol appModule3DbContextModelBuilderDefineSchoolEnrol,
                AppModule3DbContextModelBuilderDefineSchoolLevelGender appModule3DbContextModelBuilderDefineSchoolLevelGender,
                AppModule3DbContextModelBuilderDefineEducationProviderProfile appModule3DbContextModelBuilderDefineSchoolProfile,
                AppModule3DbContextModelBuilderDefineEducationProvideLocation appModule3DbContextModelBuilderDefineSchoolWgs
            )
        {
            // Reference:
            this._appModule3DbContextModelBuilderDefineAreaUnit = appModule3DbContextModelBuilderDefineAreaUnit;
            this._appModule3DbContextModelBuilderDefineAuthorityType = appModule3DbContextModelBuilderDefineAuthorityType;
            this._appModule3DbContextModelBuilderDefineCommunityBoard = appModule3DbContextModelBuilderDefineCommunityBoard;
            this._appModule3DbContextModelBuilderDefineGeneralElectorate = appModule3DbContextModelBuilderDefineGeneralElectorate;
            this._appModule3DbContextModelBuilderDefineMaoriElectorate = appModule3DbContextModelBuilderDefineMaoriElectorate;
            this._appModule3DbContextModelBuilderDefineOrganisationStatus = appModule3DbContextModelBuilderDefineOrganisationStatus;
            this._appModule3DbContextModelBuilderDefineOrganisationType = appModule3DbContextModelBuilderDefineOrganisationType;
            this._appModule3DbContextModelBuilderDefineRegion = appModule3DbContextModelBuilderDefineRegion;
            this._appModule3DbContextModelBuilderDefineRegionalCouncil = appModule3DbContextModelBuilderDefineRegionalCouncil;
            this._appModule3DbContextModelBuilderDefineRelationshipType = appModule3DbContextModelBuilderDefineRelationshipType;
            this._appModule3DbContextModelBuilderDefineSchoolClassification = appModule3DbContextModelBuilderDefineSchoolClassification;
            this._appModule3DbContextModelBuilderDefineSchoolGender = appModule3DbContextModelBuilderDefineSchoolGender;
            this._appModule3DbContextModelBuilderDefineSchoolYearLevel = appModule3DbContextModelBuilderDefineSchoolYearLevel;
            this._appModule3DbContextModelBuilderDefineSpecialSchooling = appModule3DbContextModelBuilderDefineSpecialSchooling;
            this._appModule3DbContextModelBuilderDefineTeacherEducation = appModule3DbContextModelBuilderDefineTeacherEducation;
            this._appModule3DbContextModelBuilderDefineTerritorialAuthority = appModule3DbContextModelBuilderDefineTerritorialAuthority;
            this._appModule3DbContextModelBuilderDefineUrbanArea = appModule3DbContextModelBuilderDefineUrbanArea;
            this._appModule3DbContextModelBuilderDefineWard = appModule3DbContextModelBuilderDefineWard;
            //Data:
            this._appModule3DbContextModelBuilderDefineSchoolEnrol = appModule3DbContextModelBuilderDefineSchoolEnrol;
            this._appModule3DbContextModelBuilderDefineSchoolLevelGender = appModule3DbContextModelBuilderDefineSchoolLevelGender;
            this._appModule3DbContextModelBuilderDefineSchoolProfile = appModule3DbContextModelBuilderDefineSchoolProfile;
            this._appModule3DbContextModelBuilderDefineSchoolWgs = appModule3DbContextModelBuilderDefineSchoolWgs;
        }


        public void Initialize(DbModelBuilder modelBuilder)
        {
            //if (!PowershellServiceLocatorConfig.Activated)
            //{
            //    DefineByReflection(modelBuilder);
            //}
            //else
            //{
            //    //Reflection does not work under Powershell, so:
            DefineByHand(modelBuilder);
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

            AppDependencyLocator.Current.GetAllInstances<IHasAppModule3DbContextModelBuilderInitializer>()
                .ForEach(x => x.Define(modelBuilder));
        }

        private void DefineByHand(DbModelBuilder modelBuilder)
        {
            // Reference Data:
            _appModule3DbContextModelBuilderDefineAreaUnit.Define(modelBuilder);
            _appModule3DbContextModelBuilderDefineAuthorityType.Define(modelBuilder);
            _appModule3DbContextModelBuilderDefineCommunityBoard.Define(modelBuilder);
            _appModule3DbContextModelBuilderDefineGeneralElectorate.Define(modelBuilder);
            _appModule3DbContextModelBuilderDefineMaoriElectorate.Define(modelBuilder);
            _appModule3DbContextModelBuilderDefineOrganisationStatus.Define(modelBuilder);
            _appModule3DbContextModelBuilderDefineOrganisationType.Define(modelBuilder);
            _appModule3DbContextModelBuilderDefineRegion.Define(modelBuilder);
            _appModule3DbContextModelBuilderDefineRegionalCouncil.Define(modelBuilder);
            _appModule3DbContextModelBuilderDefineRelationshipType.Define(modelBuilder);
            _appModule3DbContextModelBuilderDefineSchoolClassification.Define(modelBuilder);
            _appModule3DbContextModelBuilderDefineSchoolGender.Define(modelBuilder);
            _appModule3DbContextModelBuilderDefineSchoolYearLevel.Define(modelBuilder);
            _appModule3DbContextModelBuilderDefineSpecialSchooling.Define(modelBuilder);
            _appModule3DbContextModelBuilderDefineTeacherEducation.Define(modelBuilder);
            _appModule3DbContextModelBuilderDefineTerritorialAuthority.Define(modelBuilder);
            _appModule3DbContextModelBuilderDefineUrbanArea.Define(modelBuilder);
            _appModule3DbContextModelBuilderDefineWard.Define(modelBuilder);
            // Data:
            _appModule3DbContextModelBuilderDefineSchoolWgs.Define(modelBuilder);
            _appModule3DbContextModelBuilderDefineSchoolEnrol.Define(modelBuilder);
            _appModule3DbContextModelBuilderDefineSchoolLevelGender.Define(modelBuilder);
            _appModule3DbContextModelBuilderDefineSchoolProfile.Define(modelBuilder);


        }
    }
}