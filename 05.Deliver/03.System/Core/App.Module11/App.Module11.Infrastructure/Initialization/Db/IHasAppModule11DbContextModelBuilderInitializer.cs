namespace App.Module11.Infrastructure.Initialization.Db
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Initialization;

    public interface IHasAppModule11DbContextModelBuilderInitializer : IHasInitializer, IHasModuleSpecificIdentifier
    {
        void Define(DbModelBuilder modelBuilder);
    }
}