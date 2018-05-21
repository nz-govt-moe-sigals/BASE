namespace App.Module3.Infrastructure.Initialization.Db
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Initialization;

    public interface IHasAppModule3DbContextModelBuilderInitializer : IHasInitializer
    {
        void Define(DbModelBuilder modelBuilder);
    }
}