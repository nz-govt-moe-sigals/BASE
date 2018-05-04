namespace App.Module2.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Module2.DbContextModelBuilder;
    using App.Module2.Infrastructure.Initialization;
    using App.Module2.Infrastructure.Initialization.Db;

    public class AppModule2DbModelBuilderOrchestrator
    {
        private readonly AppModule2DbContextModelBuilderDefineBody _appModule2DbContextModelBuilderDefineBody;
        private readonly AppModule2DbContextModelBuilderDefineBodyAlias _appModule2DbContextModelBuilderDefineBodyAlias;
        private readonly AppModule2DbContextModelBuilderDefineBodyCategory _appModule2DbContextModelBuilderDefineBodyCategory;
        private readonly AppModule2DbContextModelBuilderDefineBodyChannel _appModule2DbContextModelBuilderDefineBodyChannel;
        private readonly AppModule2DbContextModelBuilderDefineBodyClaim _appModule2DbContextModelBuilderDefineBodyClaim;
        private readonly AppModule2DbContextModelBuilderDefineBodyProperty _appModule2DbContextModelBuilderDefineBodyProperty;
        private readonly AppModule2DbContextModelBuilderDefineSchoolAuthority _appModule2DbContextModelBuilderDefineSchoolAuthority;
        private readonly AppModule2DbContextModelBuilderDefineSchoolDecile _appModule2DbContextModelBuilderDefineSchoolDecile;
        private readonly AppModule2DbContextModelBuilderDefineSchoolDefinition _appModule2DbContextModelBuilderDefineSchoolDefinition;
        private readonly AppModule2DbContextModelBuilderDefineSchoolEducationRegion _appModule2DbContextModelBuilderDefineSchoolEducationRegion;
        private readonly AppModule2DbContextModelBuilderDefineSchoolGender _appModule2DbContextModelBuilderDefineSchoolGender;
        private readonly AppModule2DbContextModelBuilderDefineSchoolGeneralElectorate _appModule2DbContextModelBuilderDefineSchoolGeneralElectorate;
        private readonly AppModule2DbContextModelBuilderDefineSchoolMinistryOfEducationLocalOffice _appModule2DbContextModelBuilderDefineSchoolMinistryOfEducationLocalOffice;
        private readonly AppModule2DbContextModelBuilderDefineSchoolMoariElectorate _appModule2DbContextModelBuilderDefineSchoolMoariElectorate;
        private readonly AppModule2DbContextModelBuilderDefineSchoolRegionalCouncil _appModule2DbContextModelBuilderDefineSchoolRegionalCouncil;
        private readonly AppModule2DbContextModelBuilderDefineSchoolTerritorialAuthoritywithAucklandLocalBoard _appModule2DbContextModelBuilderDefineSchoolTerritorialAuthoritywithAucklandLocalBoard;
        private readonly AppModule2DbContextModelBuilderDefineSchoolType _appModule2DbContextModelBuilderDefineSchoolType;
        private readonly AppModule2DbContextModelBuilderDefineEducationOrganisation _appModule2DbContextModelBuilderDefineEducationOrganisation;

        public AppModule2DbModelBuilderOrchestrator(
            AppModule2DbContextModelBuilderDefineBody appModule2DbContextModelBuilderDefineBody,
            AppModule2DbContextModelBuilderDefineBodyAlias appModule2DbContextModelBuilderDefineBodyAlias,
                AppModule2DbContextModelBuilderDefineBodyCategory appModule2DbContextModelBuilderDefineBodyCategory,
                AppModule2DbContextModelBuilderDefineBodyChannel appModule2DbContextModelBuilderDefineBodyChannel,
            AppModule2DbContextModelBuilderDefineBodyClaim appModule2DbContextModelBuilderDefineBodyClaim,
            AppModule2DbContextModelBuilderDefineBodyProperty appModule2DbContextModelBuilderDefineBodyProperty,



        AppModule2DbContextModelBuilderDefineSchoolAuthority appModule2DbContextModelBuilderDefineSchoolAuthority,
        AppModule2DbContextModelBuilderDefineSchoolDecile appModule2DbContextModelBuilderDefineSchoolDecile,
        AppModule2DbContextModelBuilderDefineSchoolDefinition appModule2DbContextModelBuilderDefineSchoolDefinition,
        AppModule2DbContextModelBuilderDefineSchoolEducationRegion appModule2DbContextModelBuilderDefineSchoolEducationRegion,
        AppModule2DbContextModelBuilderDefineSchoolGender appModule2DbContextModelBuilderDefineSchoolGender,
        AppModule2DbContextModelBuilderDefineSchoolGeneralElectorate appModule2DbContextModelBuilderDefineSchoolGeneralElectorate,
        AppModule2DbContextModelBuilderDefineSchoolMinistryOfEducationLocalOffice appModule2DbContextModelBuilderDefineSchoolMinistryOfEducationLocalOffice,
        AppModule2DbContextModelBuilderDefineSchoolMoariElectorate appModule2DbContextModelBuilderDefineSchoolMoariElectorate,
        AppModule2DbContextModelBuilderDefineSchoolRegionalCouncil appModule2DbContextModelBuilderDefineSchoolRegionalCouncil,
        AppModule2DbContextModelBuilderDefineSchoolTerritorialAuthoritywithAucklandLocalBoard appModule2DbContextModelBuilderDefineSchoolTerritorialAuthoritywithAucklandLocalBoard,
        AppModule2DbContextModelBuilderDefineSchoolType appModule2DbContextModelBuilderDefineSchoolType,

        AppModule2DbContextModelBuilderDefineEducationOrganisation appModule2DbContextModelBuilderDefineEducationOrganisation
            )

        {
            this._appModule2DbContextModelBuilderDefineBody = appModule2DbContextModelBuilderDefineBody;
            this._appModule2DbContextModelBuilderDefineBodyAlias = appModule2DbContextModelBuilderDefineBodyAlias;
            this._appModule2DbContextModelBuilderDefineBodyCategory = appModule2DbContextModelBuilderDefineBodyCategory;
            this._appModule2DbContextModelBuilderDefineBodyChannel = appModule2DbContextModelBuilderDefineBodyChannel;
            this._appModule2DbContextModelBuilderDefineBodyClaim = appModule2DbContextModelBuilderDefineBodyClaim;
            this._appModule2DbContextModelBuilderDefineBodyProperty = appModule2DbContextModelBuilderDefineBodyProperty;

            this._appModule2DbContextModelBuilderDefineSchoolAuthority = appModule2DbContextModelBuilderDefineSchoolAuthority;
            this._appModule2DbContextModelBuilderDefineSchoolDecile = appModule2DbContextModelBuilderDefineSchoolDecile;
            this._appModule2DbContextModelBuilderDefineSchoolDefinition = appModule2DbContextModelBuilderDefineSchoolDefinition;
            this._appModule2DbContextModelBuilderDefineSchoolEducationRegion = appModule2DbContextModelBuilderDefineSchoolEducationRegion;
            this._appModule2DbContextModelBuilderDefineSchoolGender = appModule2DbContextModelBuilderDefineSchoolGender;
            this._appModule2DbContextModelBuilderDefineSchoolGeneralElectorate = appModule2DbContextModelBuilderDefineSchoolGeneralElectorate;
            this._appModule2DbContextModelBuilderDefineSchoolMinistryOfEducationLocalOffice = appModule2DbContextModelBuilderDefineSchoolMinistryOfEducationLocalOffice;
            this._appModule2DbContextModelBuilderDefineSchoolMoariElectorate = appModule2DbContextModelBuilderDefineSchoolMoariElectorate;
            this._appModule2DbContextModelBuilderDefineSchoolRegionalCouncil = appModule2DbContextModelBuilderDefineSchoolRegionalCouncil;
            this._appModule2DbContextModelBuilderDefineSchoolTerritorialAuthoritywithAucklandLocalBoard = appModule2DbContextModelBuilderDefineSchoolTerritorialAuthoritywithAucklandLocalBoard;
            this._appModule2DbContextModelBuilderDefineSchoolType = appModule2DbContextModelBuilderDefineSchoolType;

            this._appModule2DbContextModelBuilderDefineEducationOrganisation = appModule2DbContextModelBuilderDefineEducationOrganisation;
        }

        public void Initialize(DbModelBuilder modelBuilder)
        {
            //if (!PowershellServiceLocatorConfig.Activated)
            //{
            //    DefineByReflection(modelBuilder);
            //}
            //else
            //{
            //Reflection does not work under Powershell, so:
            DefineByHand(modelBuilder);
            //}
        }

        private void DefineByReflection(DbModelBuilder modelBuilder)
        {
            // You can initialize manually or by Convention over Configuration
            // using a combination of common interface and reflection.
            AppDependencyLocator.Current.GetAllInstances<IHasAppModule2DbContextModelBuilderInitializer>()
                .ForEach(x => x.Define(modelBuilder));
        }

        private void DefineByHand(DbModelBuilder modelBuilder)
        {
            this._appModule2DbContextModelBuilderDefineBody.Define(modelBuilder);
            this._appModule2DbContextModelBuilderDefineBodyAlias.Define(modelBuilder);
            this._appModule2DbContextModelBuilderDefineBodyCategory.Define(modelBuilder);
            this._appModule2DbContextModelBuilderDefineBodyChannel.Define(modelBuilder);
            this._appModule2DbContextModelBuilderDefineBodyClaim.Define(modelBuilder);
            this._appModule2DbContextModelBuilderDefineBodyProperty.Define(modelBuilder);

            this._appModule2DbContextModelBuilderDefineSchoolAuthority.Define(modelBuilder);
            this._appModule2DbContextModelBuilderDefineSchoolDecile.Define(modelBuilder);
            this._appModule2DbContextModelBuilderDefineSchoolDefinition.Define(modelBuilder);
            this._appModule2DbContextModelBuilderDefineSchoolEducationRegion.Define(modelBuilder);
            this._appModule2DbContextModelBuilderDefineSchoolGender.Define(modelBuilder);
            this._appModule2DbContextModelBuilderDefineSchoolGeneralElectorate.Define(modelBuilder);
            this._appModule2DbContextModelBuilderDefineSchoolMinistryOfEducationLocalOffice.Define(modelBuilder);
            this._appModule2DbContextModelBuilderDefineSchoolMoariElectorate.Define(modelBuilder);
            this._appModule2DbContextModelBuilderDefineSchoolRegionalCouncil.Define(modelBuilder);
            this._appModule2DbContextModelBuilderDefineSchoolTerritorialAuthoritywithAucklandLocalBoard.Define(modelBuilder);
            this._appModule2DbContextModelBuilderDefineSchoolType.Define(modelBuilder);

            this._appModule2DbContextModelBuilderDefineEducationOrganisation.Define(modelBuilder);
        }
    }
}