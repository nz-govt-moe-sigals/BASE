using App.Core.Infrastructure.Initialization.DependencyResolution;

namespace App.Module02.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using System.Diagnostics;
    using App.Core.Infrastructure.Contracts;
    using App.Module02.Infrastructure.Initialization;
    using App.Module02.Infrastructure.Initialization.Db;

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
            Debugger.Launch();
            var r = AppDependencyLocator.Current.GetAllInstances<IHasAppModuleDbContextModelBuilderInitializer>();
                
            r.ForEach(x => {
                if (!(typeof(IHasIgnoreThis).IsAssignableFrom(x.GetType()))) { x.Define(modelBuilder); }
            });
        }


    }
}

