namespace App.Module2.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Module2.DbContextModelBuilder;
    using App.Module2.Infrastructure.Initialization;
    using App.Module2.Infrastructure.Initialization.Db;

    public class AppModule2DbModelBuilderOrchestrator
    {
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
            new AppModule2DbContextModelBuilderDefineBody().Define(modelBuilder);
            new AppModule2DbContextModelBuilderDefineBodyAlias().Define(modelBuilder);
            new AppModule2DbContextModelBuilderDefineBodyCategory().Define(modelBuilder);
            new AppModule2DbContextModelBuilderDefineBodyChannel().Define(modelBuilder);
            new AppModule2DbContextModelBuilderDefineBodyClaim().Define(modelBuilder);
            new AppModule2DbContextModelBuilderDefineBodyProperty().Define(modelBuilder);

            new AppModule2DbContextModelBuilderDefineEducationOrganisation().Define(modelBuilder);
        }
    }
}