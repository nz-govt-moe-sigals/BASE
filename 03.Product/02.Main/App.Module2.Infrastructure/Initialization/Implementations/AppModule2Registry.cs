namespace App.Module2.Infrastructure.Initialization.Implementations
{
    using App.Module2.Infrastructure.Db.Context;
    using StructureMap;

    // Each Module has its own registry for handling specific cases.
    // The general registration of Services is handled via the Core
    // StructureMap Registry (ie, Services, Controllers, etc.)
    public class AppModule2Registry : Registry
    {
        public AppModule2Registry()
        {
            Scan(
                scan =>
                {
                    // Db Model Definitions, and Seeding are unique to a specific Module Context:
                    AppModule2ServiceLocatorInitializer.ScanForCoreInitializers()
                        .ForEach(x => scan.AddAllTypesOf(x));
                });

            //And this registers the Module's Db Factory:
            this.RegisterDbContextInHttpContext<AppModule2DbContext>("Module2");
            //For<AppModule2DbContext>()
            //    .Use(y => new AppModule2DbContext());
        }
    }
}