using App.Module80.Shared.Contracts;

namespace App.Module80.Infrastructure.Initialization.Db
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Initialization;

    public interface IHasAppModuleDbContextModelBuilderInitializer : IHasInitializer, IHasModuleSpecificIdentifier
    {
        void Define(DbModelBuilder modelBuilder);
    }
}

