using App.Core.Infrastructure.Initialization.DependencyResolution;

namespace App.Module1.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Module1.Infrastructure.Initialization;
    using App.Module1.Infrastructure.Initialization.Db;

    public class AppModule1DbModelBuilderOrchestrator
    {
        private readonly AppModule1DbContextModelBuilderDefineExample _appModule1DbContextModelBuilderDefineExample;

        public AppModule1DbModelBuilderOrchestrator(AppModule1DbContextModelBuilderDefineExample appModule1DbContextModelBuilderDefineExample)
        {
            this._appModule1DbContextModelBuilderDefineExample = appModule1DbContextModelBuilderDefineExample;
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

            AppDependencyLocator.Current.GetAllInstances<IHasAppModule1DbContextModelBuilderInitializer>()
                .ForEach(x => x.Define(modelBuilder));
        }

        private void DefineByHand(DbModelBuilder modelBuilder)
        {
            this._appModule1DbContextModelBuilderDefineExample.Define(modelBuilder);
        }
    }
}