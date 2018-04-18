namespace App.Core.Infrastructure.Db.Schema.Conventions
{
    using System;
    using System.Data.Entity;
    using App.Core.Shared.Models;
    using App.Core.Shared.Models.Entities;


    /// <summary>
    /// Base Schema Definition 
    /// for any Tenant specific Entity.
    /// <para>
    /// Adds the definition of 
    /// TenantFK (but not a Tenant object)
    /// on top of
    /// Id, Timestamp, RecordState, CreatedOn/By, LastModifiedOn/By, DeletedOn/By
    /// </para>
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Db.Schema.Conventions.NonTenantFKEtcConvention" />
    public class TenantFKEtcConvention : NonTenantFKEtcConvention
    {
        public new void Define<T>(DbModelBuilder modelBuilder, ref int order, Func<int, int> injectedPropertyDefs = null)
            where T : TenantFKTimestampedAuditedRecordStatedGuidIdEntityBase
        {
            // Call underlying method to finish 
            base.Define<T>(modelBuilder, ref order, injectedPropertyDefs);
            //Wrong way: new NonTenantFKEtcConvention().Define<T>(modelBuilder, ref order);

            //11:
            modelBuilder.Entity<T>()
                .Property(x => x.TenantFK)
                .HasColumnOrder(order++)
                .IsRequired()
                ;
            if (injectedPropertyDefs!=null){order = injectedPropertyDefs.Invoke(order);}

            //modelBuilder.Entity<T>()
            //    .HasRequired(x => x.Tenant)
            //    .WithMany()
            //    .HasForeignKey(x => x.TenantFK)
            //    .WillCascadeOnDelete(false);
        }
    }
}