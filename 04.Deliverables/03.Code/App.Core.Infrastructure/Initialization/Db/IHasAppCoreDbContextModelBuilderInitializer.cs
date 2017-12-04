namespace App.Core.Infrastructure.Initialization.Db
{
    using System.Data.Entity;

    public interface IHasAppCoreDbContextModelBuilderInitializer : IHasInitializer
    {
        void Define(DbModelBuilder modelBuilder);
    }
}