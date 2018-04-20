namespace App.Module2.Infrastructure.Initialization.Db
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Initialization;

    public interface IHasAppModule1DbContextModelBuilderInitializer : IHasInitializer
    {
        void Define(DbModelBuilder modelBuilder);
    }
}