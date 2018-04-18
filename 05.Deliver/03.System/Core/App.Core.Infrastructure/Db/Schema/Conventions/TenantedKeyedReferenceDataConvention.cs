namespace App.Core.Infrastructure.Db.Schema.Conventions
{
    using System.Data.Entity;
    using App.Core.Shared.Models.Entities.Base;

    /// <summary>
    /// Adds the definition of 
    /// Enabled, Key, Text, DisplayOrderHint, DisplayStyleHint
    /// on top of
    /// TenantFK (but not a Tenant object)
    /// on top of
    /// Id, Timestamp, RecordState, CreatedOn/By, LastModifiedOn/By, DeletedOn/By
    /// <para>
    /// NOTE:
    /// I think the deciesion to not enherit from TenantedReferenceDataConventions 
    /// was only done to control the order of columns (so that Key is *after* 
    /// Enabled, rather than before). 
    /// Feels a bit dumb now...
    /// </para>
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Db.Schema.Conventions.TenantFKEtcConvention" />
    public class TenantedKeyedReferenceDataConvention : TenantedReferenceDataConvention
    {
        public new void Define<T>(DbModelBuilder modelBuilder, ref int order)
            where T : TenantedKeyedGuidIdReferenceDataBase
        {
            // Call underlying method first:
            base.Define<T>(modelBuilder, ref order, o =>
            {
                if (o != 11)
                {
                    return o;
                }

                // Now inject into the position you want added.
                // It will push over the existing ones... I think...
                modelBuilder.Entity<T>()
                    .Property(x => x.Key)
                    .HasColumnOrder(o++)
                    .IsRequired();

                return o;
            });
        }
    }
}