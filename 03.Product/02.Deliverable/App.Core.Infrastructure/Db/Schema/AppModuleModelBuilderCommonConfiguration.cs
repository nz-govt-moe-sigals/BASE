namespace App.Core.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Core.Shared.Models.Entities;

    public static class AppModuleModelBuilderCommonConfiguration
    {
        public static void Initialize(DbModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Tenant>();
            modelBuilder.Ignore<TenantProperty>();
            modelBuilder.Ignore<TenantClaim>();

            modelBuilder.Ignore<Principal>();
            modelBuilder.Ignore<PrincipalProperty>();
            modelBuilder.Ignore<PrincipalClaim>();

            modelBuilder.Ignore<Session>();
            modelBuilder.Ignore<SessionOperation>();

            modelBuilder.Conventions.Add<IdConvention>();
        }
    }
}