namespace App.Module3.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Module3.Infrastructure.Initialization;
    using App.Module3.Infrastructure.Initialization.Db;

    public class AppModule3DbModelBuilderOrchestrator
    {
        private readonly AppModule3DbContextModelBuilderDefineExample _appModule3DbContextModelBuilderDefineExample;

        public AppModule3DbModelBuilderOrchestrator(AppModule3DbContextModelBuilderDefineExample appModule3DbContextModelBuilderDefineExample)
        {
            this._appModule3DbContextModelBuilderDefineExample = appModule3DbContextModelBuilderDefineExample;
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
            this._appModule3DbContextModelBuilderDefineExample.Define(modelBuilder);
            AppModule3DbContextModelBuilderDefineExtractWatermark.DefineTable(modelBuilder);
        }
    }
}