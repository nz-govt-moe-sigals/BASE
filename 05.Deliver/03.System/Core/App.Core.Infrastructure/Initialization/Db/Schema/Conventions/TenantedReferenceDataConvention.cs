namespace App.Core.Infrastructure.Db.Schema.Conventions
{
    using System;
    using System.Data.Entity;
    using App.Core.Shared.Models.Entities.Base;
    using Microsoft.Azure.KeyVault.Models;

    /// <summary>
    /// Adds the definition of 
    /// Enabled, Text, DisplayOrderHint, DisplayStyleHint
    /// on top of
    /// TenantFK (but not a Tenant object)
    /// on top of
    /// Id, Timestamp, RecordState, CreatedOn/By, LastModifiedOn/By, DeletedOn/By
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Db.Schema.Conventions.TenantFKEtcConvention" />
    public class TenantedReferenceDataConvention : TenantFKEtcConvention
    {
        public new void Define<T>(DbModelBuilder modelBuilder, ref int order, Func<int, int> injectedPropertyDefs =null)
            where T: TenantedGuidIdReferenceDataBase 
        {
            // Call underlying method first:
            base.Define<T>(modelBuilder,ref order, injectedPropertyDefs);

            // then specific additions:

            //12:
            modelBuilder.Entity<T>()
                .Property(x => x.Enabled)
                .HasColumnOrder(order++)
                .IsRequired();
            if (injectedPropertyDefs!=null){order = injectedPropertyDefs.Invoke(order);}

            //-- Might inject keys here...(if order == 12...)

            //13:
            modelBuilder.Entity<T>()
                .Property(x => x.Text)
                .HasColumnOrder(order++)
                .HasMaxLength(Constants.Db.TextFieldSizes.X64)
                .IsRequired();
            if (injectedPropertyDefs!=null){order = injectedPropertyDefs.Invoke(order);}

            //14:
            modelBuilder.Entity<T>()
                .Property(x => x.DisplayOrderHint)
                .HasColumnOrder(order++)
                .IsRequired();
            if (injectedPropertyDefs!=null){order = injectedPropertyDefs.Invoke(order);}

            //15:
            modelBuilder.Entity<T>()
                .Property(x => x.DisplayStyleHint)
                .HasColumnOrder(order++)
                .HasMaxLength(Constants.Db.TextFieldSizes.X64)
                .IsOptional();
            if (injectedPropertyDefs!=null){order = injectedPropertyDefs.Invoke(order);}

        }
    }
}