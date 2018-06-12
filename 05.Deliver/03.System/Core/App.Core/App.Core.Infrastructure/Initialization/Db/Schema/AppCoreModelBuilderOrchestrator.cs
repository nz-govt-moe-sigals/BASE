namespace App.Core.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Contracts;
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Infrastructure.Initialization.DependencyResolution;

    // A specialised class to define a DbContext model. 
    // It's extracted from the DbContext itself for SOC
    // objectives (when done by manual method, can end up with
    // lots of models, and it gets unwieldy, making DbContext
    // hard to grock.
    public class AppCoreModelBuilderOrchestrator
    {

        public AppCoreModelBuilderOrchestrator()
        {

        }

        //Invoked from AppCoreDbContext/OnModelCreating
        public void Initialize(DbModelBuilder modelBuilder)
        {
            DefineByReflection(modelBuilder);
        }


        private void DefineByReflection(DbModelBuilder modelBuilder)
        {
            // You can initialize manually or by Convention over Configuration
            // using a combination of common interface and reflection.
            AppDependencyLocator.Current.GetAllInstances<IHasAppModuleDbContextModelBuilderInitializer>()
                .ForEach(x => { if (!(typeof(IHasIgnoreThis).IsAssignableFrom(x.GetType()))) { x.Define(modelBuilder); } });
        }

    }
}