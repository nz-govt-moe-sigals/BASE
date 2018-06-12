namespace App.Core.Infrastructure.Initialization.Db
{
    using System.Data.Entity;

    public interface IHasAppModuleDbContextModelBuilderInitializer : IHasInitializer
    {
        void Define(DbModelBuilder modelBuilder);
    }
}