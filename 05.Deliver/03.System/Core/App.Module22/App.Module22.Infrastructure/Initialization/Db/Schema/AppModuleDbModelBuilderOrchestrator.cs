using App.Core.Infrastructure.Initialization.DependencyResolution;

namespace App.Module22.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Module22.Infrastructure.Initialization;
    using App.Module22.Infrastructure.Initialization.Db;

    public class AppModuleDbModelBuilderOrchestrator : IHasModuleSpecificIdentifier
    {

        public AppModuleDbModelBuilderOrchestrator()
        {
        }


        public void Initialize(DbModelBuilder modelBuilder)
        {
            DefineByReflection(modelBuilder);
        }

        private void DefineByReflection(DbModelBuilder modelBuilder)
        {
            // You can initialize manually or by Convention over Configuration
            // using a combination of common interface and reflection.

            AppDependencyLocator.Current.GetAllInstances<IHasAppModuleDbContextModelBuilderInitializer>()
                .ForEach(x => x.Define(modelBuilder));
        }


    }
}

