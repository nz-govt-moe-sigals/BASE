namespace App.Core.Infrastructure.Db.Schema.Conventions
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using App.Core.Shared.Models;
    using App.Core.Shared.Models.Entities;

    public class TenantFKEtcConvention : NonTenantFKEtcConvention
    {
        public void Define<T>(DbModelBuilder modelBuilder, ref int order)
            where T : TenantFKTimestampedAuditedRecordStatedGuidIdEntityBase
        {
            new NonTenantFKEtcConvention().Define<T>(modelBuilder, ref order);

            modelBuilder.Entity<T>()
                .Property(x => x.TenantFK)
                .HasColumnOrder(order++)
                .IsRequired()
                ;

            //modelBuilder.Entity<T>()
            //    .HasRequired(x => x.Tenant)
            //    .WithMany()
            //    .HasForeignKey(x => x.TenantFK)
            //    .WillCascadeOnDelete(false);
        }
    }

    public class NonTenantFKEtcConvention  
    {
        public void Define<T>(DbModelBuilder modelBuilder, ref int order)
            where T : UntenantedTimestampedAuditedRecordStatedGuidIdEntityBase
        {
            Define<T,Guid>(modelBuilder, ref order);
        }

        public void Define<T,TId>(DbModelBuilder modelBuilder, ref int order)
            where T : UntenantedTimestampedAuditedRecordStatedCustomIdEntityBase<TId>
            where TId: struct
        {
            modelBuilder.Entity<T>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<T>()
                .Property(x => x.Id)
                .HasColumnOrder(order++)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsRequired();

            modelBuilder.Entity<T>()
                .Property(x => x.Timestamp)
                .IsConcurrencyToken()
                .IsRowVersion()
                .HasColumnOrder(order++)
                //.IsRequired()
                ;

            modelBuilder.Entity<T>()
                .Property(x => x.RecordState)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<T>()
                .Property(x => x.CreatedOnUtc)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<T>()
                .Property(x => x.CreatedByPrincipalId)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<T>()
                .Property(x => x.LastModifiedOnUtc)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<T>()
                .Property(x => x.LastModifiedByPrincipalId)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<T>()
                .Property(x => x.DeletedOnUtc)
                .HasColumnOrder(order++)
                .IsOptional();

            modelBuilder.Entity<T>()
                .Property(x => x.DeletedByPrincipalId)
                .HasColumnOrder(order++)
                .IsOptional();
        }
    }
}