using App.Core.Infrastructure.Initialization.DependencyResolution;

namespace App.Module02.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Module02.DbContextModelBuilder;
    using App.Module02.Infrastructure.Initialization;
    using App.Module02.Infrastructure.Initialization.Db;

    public class AppModuleDbModelBuilderOrchestrator: IHasModuleSpecificIdentifier
    {
        private readonly AppModuleDbContextModelBuilderDefineBody _appModuleDbContextModelBuilderDefineBody;
        private readonly AppModuleDbContextModelBuilderDefineBodyAlias _appModuleDbContextModelBuilderDefineBodyAlias;
        private readonly AppModuleDbContextModelBuilderDefineBodyCategory _appModuleDbContextModelBuilderDefineBodyCategory;
        private readonly AppModuleDbContextModelBuilderDefineBodyChannel _appModuleDbContextModelBuilderDefineBodyChannel;
        private readonly AppModuleDbContextModelBuilderDefineBodyClaim _appModuleDbContextModelBuilderDefineBodyClaim;
        private readonly AppModuleDbContextModelBuilderDefineBodyProperty _appModuleDbContextModelBuilderDefineBodyProperty;
        private readonly AppModuleDbContextModelBuilderDefineSchoolAuthority _appModuleDbContextModelBuilderDefineSchoolAuthority;
        private readonly AppModuleDbContextModelBuilderDefineSchoolDecile _appModuleDbContextModelBuilderDefineSchoolDecile;
        private readonly AppModuleDbContextModelBuilderDefineSchoolDefinition _appModuleDbContextModelBuilderDefineSchoolDefinition;
        private readonly AppModuleDbContextModelBuilderDefineSchoolEducationRegion _appModuleDbContextModelBuilderDefineSchoolEducationRegion;
        private readonly AppModuleDbContextModelBuilderDefineSchoolGender _appModuleDbContextModelBuilderDefineSchoolGender;
        private readonly AppModuleDbContextModelBuilderDefineSchoolGeneralElectorate _appModuleDbContextModelBuilderDefineSchoolGeneralElectorate;
        private readonly AppModuleDbContextModelBuilderDefineSchoolMinistryOfEducationLocalOffice _appModuleDbContextModelBuilderDefineSchoolMinistryOfEducationLocalOffice;
        private readonly AppModuleDbContextModelBuilderDefineSchoolMoariElectorate _appModuleDbContextModelBuilderDefineSchoolMoariElectorate;
        private readonly AppModuleDbContextModelBuilderDefineSchoolRegionalCouncil _appModuleDbContextModelBuilderDefineSchoolRegionalCouncil;
        private readonly AppModuleDbContextModelBuilderDefineSchoolTerritorialAuthoritywithAucklandLocalBoard _appModuleDbContextModelBuilderDefineSchoolTerritorialAuthoritywithAucklandLocalBoard;
        private readonly AppModuleDbContextModelBuilderDefineSchoolType _appModuleDbContextModelBuilderDefineSchoolType;
        private readonly AppModuleDbContextModelBuilderDefineEducationOrganisation _appModuleDbContextModelBuilderDefineEducationOrganisation;

        public AppModuleDbModelBuilderOrchestrator(
            AppModuleDbContextModelBuilderDefineBody appModuleDbContextModelBuilderDefineBody,
            AppModuleDbContextModelBuilderDefineBodyAlias appModuleDbContextModelBuilderDefineBodyAlias,
                AppModuleDbContextModelBuilderDefineBodyCategory appModuleDbContextModelBuilderDefineBodyCategory,
                AppModuleDbContextModelBuilderDefineBodyChannel appModuleDbContextModelBuilderDefineBodyChannel,
            AppModuleDbContextModelBuilderDefineBodyClaim appModuleDbContextModelBuilderDefineBodyClaim,
            AppModuleDbContextModelBuilderDefineBodyProperty appModuleDbContextModelBuilderDefineBodyProperty,



        AppModuleDbContextModelBuilderDefineSchoolAuthority appModuleDbContextModelBuilderDefineSchoolAuthority,
        AppModuleDbContextModelBuilderDefineSchoolDecile appModuleDbContextModelBuilderDefineSchoolDecile,
        AppModuleDbContextModelBuilderDefineSchoolDefinition appModuleDbContextModelBuilderDefineSchoolDefinition,
        AppModuleDbContextModelBuilderDefineSchoolEducationRegion appModuleDbContextModelBuilderDefineSchoolEducationRegion,
        AppModuleDbContextModelBuilderDefineSchoolGender appModuleDbContextModelBuilderDefineSchoolGender,
        AppModuleDbContextModelBuilderDefineSchoolGeneralElectorate appModuleDbContextModelBuilderDefineSchoolGeneralElectorate,
        AppModuleDbContextModelBuilderDefineSchoolMinistryOfEducationLocalOffice appModuleDbContextModelBuilderDefineSchoolMinistryOfEducationLocalOffice,
        AppModuleDbContextModelBuilderDefineSchoolMoariElectorate appModuleDbContextModelBuilderDefineSchoolMoariElectorate,
        AppModuleDbContextModelBuilderDefineSchoolRegionalCouncil appModuleDbContextModelBuilderDefineSchoolRegionalCouncil,
        AppModuleDbContextModelBuilderDefineSchoolTerritorialAuthoritywithAucklandLocalBoard appModuleDbContextModelBuilderDefineSchoolTerritorialAuthoritywithAucklandLocalBoard,
        AppModuleDbContextModelBuilderDefineSchoolType appModuleDbContextModelBuilderDefineSchoolType,

        AppModuleDbContextModelBuilderDefineEducationOrganisation appModuleDbContextModelBuilderDefineEducationOrganisation
            )

        {
            this._appModuleDbContextModelBuilderDefineBody = appModuleDbContextModelBuilderDefineBody;
            this._appModuleDbContextModelBuilderDefineBodyAlias = appModuleDbContextModelBuilderDefineBodyAlias;
            this._appModuleDbContextModelBuilderDefineBodyCategory = appModuleDbContextModelBuilderDefineBodyCategory;
            this._appModuleDbContextModelBuilderDefineBodyChannel = appModuleDbContextModelBuilderDefineBodyChannel;
            this._appModuleDbContextModelBuilderDefineBodyClaim = appModuleDbContextModelBuilderDefineBodyClaim;
            this._appModuleDbContextModelBuilderDefineBodyProperty = appModuleDbContextModelBuilderDefineBodyProperty;

            this._appModuleDbContextModelBuilderDefineSchoolAuthority = appModuleDbContextModelBuilderDefineSchoolAuthority;
            this._appModuleDbContextModelBuilderDefineSchoolDecile = appModuleDbContextModelBuilderDefineSchoolDecile;
            this._appModuleDbContextModelBuilderDefineSchoolDefinition = appModuleDbContextModelBuilderDefineSchoolDefinition;
            this._appModuleDbContextModelBuilderDefineSchoolEducationRegion = appModuleDbContextModelBuilderDefineSchoolEducationRegion;
            this._appModuleDbContextModelBuilderDefineSchoolGender = appModuleDbContextModelBuilderDefineSchoolGender;
            this._appModuleDbContextModelBuilderDefineSchoolGeneralElectorate = appModuleDbContextModelBuilderDefineSchoolGeneralElectorate;
            this._appModuleDbContextModelBuilderDefineSchoolMinistryOfEducationLocalOffice = appModuleDbContextModelBuilderDefineSchoolMinistryOfEducationLocalOffice;
            this._appModuleDbContextModelBuilderDefineSchoolMoariElectorate = appModuleDbContextModelBuilderDefineSchoolMoariElectorate;
            this._appModuleDbContextModelBuilderDefineSchoolRegionalCouncil = appModuleDbContextModelBuilderDefineSchoolRegionalCouncil;
            this._appModuleDbContextModelBuilderDefineSchoolTerritorialAuthoritywithAucklandLocalBoard = appModuleDbContextModelBuilderDefineSchoolTerritorialAuthoritywithAucklandLocalBoard;
            this._appModuleDbContextModelBuilderDefineSchoolType = appModuleDbContextModelBuilderDefineSchoolType;

            this._appModuleDbContextModelBuilderDefineEducationOrganisation = appModuleDbContextModelBuilderDefineEducationOrganisation;
        }

        public void Initialize(DbModelBuilder modelBuilder)
        {
                DefineByReflection(modelBuilder);
            //if (!PowershellServiceLocatorConfig.Activated)
            //{
            //    DefineByReflection(modelBuilder);
            //}
            //else
            //{
            //Reflection does not work under Powershell, so:
            //DefineByHand(modelBuilder);
            //}
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
        //    this._appModuleDbContextModelBuilderDefineBody.Define(modelBuilder);
        //    this._appModuleDbContextModelBuilderDefineBodyAlias.Define(modelBuilder);
        //    this._appModuleDbContextModelBuilderDefineBodyCategory.Define(modelBuilder);
        //    this._appModuleDbContextModelBuilderDefineBodyChannel.Define(modelBuilder);
        //    this._appModuleDbContextModelBuilderDefineBodyClaim.Define(modelBuilder);
        //    this._appModuleDbContextModelBuilderDefineBodyProperty.Define(modelBuilder);

        //    this._appModuleDbContextModelBuilderDefineSchoolAuthority.Define(modelBuilder);
        //    this._appModuleDbContextModelBuilderDefineSchoolDecile.Define(modelBuilder);
        //    this._appModuleDbContextModelBuilderDefineSchoolDefinition.Define(modelBuilder);
        //    this._appModuleDbContextModelBuilderDefineSchoolEducationRegion.Define(modelBuilder);
        //    this._appModuleDbContextModelBuilderDefineSchoolGender.Define(modelBuilder);
        //    this._appModuleDbContextModelBuilderDefineSchoolGeneralElectorate.Define(modelBuilder);
        //    this._appModuleDbContextModelBuilderDefineSchoolMinistryOfEducationLocalOffice.Define(modelBuilder);
        //    this._appModuleDbContextModelBuilderDefineSchoolMoariElectorate.Define(modelBuilder);
        //    this._appModuleDbContextModelBuilderDefineSchoolRegionalCouncil.Define(modelBuilder);
        //    this._appModuleDbContextModelBuilderDefineSchoolTerritorialAuthoritywithAucklandLocalBoard.Define(modelBuilder);
        //    this._appModuleDbContextModelBuilderDefineSchoolType.Define(modelBuilder);

        //    this._appModuleDbContextModelBuilderDefineEducationOrganisation.Define(modelBuilder);
        //}
    }
}