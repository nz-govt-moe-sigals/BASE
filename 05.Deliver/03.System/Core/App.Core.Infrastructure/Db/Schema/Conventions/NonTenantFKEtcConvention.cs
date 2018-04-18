namespace App.Core.Infrastructure.Db.Schema.Conventions
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using App.Core.Shared.Models.Entities;

    public class NonTenantFKEtcConvention  
    {
        public virtual void Define<T>(DbModelBuilder modelBuilder, ref int order, Func<int, int> injectedPropertyDefs = null)
            where T : UntenantedTimestampedAuditedRecordStatedGuidIdEntityBase
        {
            Define<T,Guid>(modelBuilder, ref order, injectedPropertyDefs);
        }


        public virtual void Define<T,TId>(DbModelBuilder modelBuilder, ref int order, Func<int, int> injectedPropertyDefs = null)
            where T : UntenantedTimestampedAuditedRecordStatedCustomIdEntityBase<TId>
            where TId: struct
        {
            //1:
            modelBuilder.Entity<T>()
                .HasKey(x => x.Id);
            if (injectedPropertyDefs!=null){order = injectedPropertyDefs.Invoke(order);}


            //2:
            modelBuilder.Entity<T>()
                .Property(x => x.Id)
                .HasColumnOrder(order++)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsRequired();
            if (injectedPropertyDefs!=null){order = injectedPropertyDefs.Invoke(order);}

            //3:
            modelBuilder.Entity<T>()
                .Property(x => x.Timestamp)
                .IsConcurrencyToken()
                .IsRowVersion()
                .HasColumnOrder(order++)
                //.IsRequired()
                ;
            if (injectedPropertyDefs!=null){order = injectedPropertyDefs.Invoke(order);}

            //4:
            modelBuilder.Entity<T>()
                .Property(x => x.RecordState)
                .HasColumnOrder(order++)
                .IsRequired();
            if (injectedPropertyDefs!=null){order = injectedPropertyDefs.Invoke(order);}

            //5:
            modelBuilder.Entity<T>()
                .Property(x => x.CreatedOnUtc)
                .HasColumnOrder(order++)
                .IsRequired();
            if (injectedPropertyDefs!=null){order = injectedPropertyDefs.Invoke(order);}

            //6:
            modelBuilder.Entity<T>()
                .Property(x => x.CreatedByPrincipalId)
                .HasColumnOrder(order++)
                .IsRequired();
            if (injectedPropertyDefs!=null){order = injectedPropertyDefs.Invoke(order);}

            //7:
            modelBuilder.Entity<T>()
                .Property(x => x.LastModifiedOnUtc)
                .HasColumnOrder(order++)
                .IsRequired();
            if (injectedPropertyDefs!=null){order = injectedPropertyDefs.Invoke(order);}

            //8:
            modelBuilder.Entity<T>()
                .Property(x => x.LastModifiedByPrincipalId)
                .HasColumnOrder(order++)
                .IsRequired();
            if (injectedPropertyDefs!=null){order = injectedPropertyDefs.Invoke(order);}

            //9:
            modelBuilder.Entity<T>()
                .Property(x => x.DeletedOnUtc)
                .HasColumnOrder(order++)
                .IsOptional();
            if (injectedPropertyDefs!=null){order = injectedPropertyDefs.Invoke(order);}

            //10:
            modelBuilder.Entity<T>()
                .Property(x => x.DeletedByPrincipalId)
                .HasColumnOrder(order++)
                .IsOptional();
            if (injectedPropertyDefs!=null){order = injectedPropertyDefs.Invoke(order);}
        }
    }
}