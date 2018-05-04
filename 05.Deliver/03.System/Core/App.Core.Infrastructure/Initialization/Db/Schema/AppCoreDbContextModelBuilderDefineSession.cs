namespace App.Core.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Shared.Models.Entities;

    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppCoreDbContextModelBuilderDefineSession : IHasAppCoreDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;


            new NonTenantFKEtcConvention().Define<Session>(modelBuilder, ref order);


            modelBuilder.Entity<Session>()
                .Property(x => x.Enabled)
                .IsRequired();



            modelBuilder.Entity<Session>()
                .HasRequired(x => x.Principal)
                .WithMany()
                .HasForeignKey(x => x.PrincipalFK);

            modelBuilder.Entity<Session>()
                .HasMany(x => x.Operations)
                .WithOptional()
                .HasForeignKey(x => x.OwnerFK);

        }
    }
}