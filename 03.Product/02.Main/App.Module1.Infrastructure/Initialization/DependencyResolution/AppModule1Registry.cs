namespace App.Module1.Infrastructure.Initialization.DependencyResolution
{
    using App.Module1.Infrastructure.Db.Context;
    using StructureMap;

    // Each Module has its own registry for handling specific cases.
    // The general registration of Services is handled via the Core
    // StructureMap Registry (ie, Services, Controllers, etc.)
    public class AppModule1Registry : Registry
    {
        public AppModule1Registry()
        {
            Scan(
                scan =>
                {
                    // Db Model Definitions, and Seeding are unique to a specific Module Context:
                    AppModule1ServiceLocatorInitializer.ScanForCoreInitializers()
                        .ForEach(x => scan.AddAllTypesOf(x));
                });

            //And this registers the Module's Db Factory:
            this.RegisterDbContextInHttpContext<AppModule1DbContext>("Module1");
            //For<AppModule1DbContext>()
            //    .Use(y => new AppModule1DbContext());
        }
    }
}