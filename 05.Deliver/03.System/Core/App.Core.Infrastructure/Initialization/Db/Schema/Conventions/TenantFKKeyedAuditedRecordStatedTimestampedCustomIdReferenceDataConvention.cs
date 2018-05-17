namespace App.Core.Infrastructure.Db.Schema.Conventions
{
    using System;
    using System.Data.Entity;
    using App.Core.Shared.Models;
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
    /// <seealso cref="App.Core.Infrastructure.Db.Schema.Conventions.TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention" />
    public class TenantFKKeyedAuditedRecordStatedTimestampedCustomIdReferenceDataConvention
    {
        public void Define<T,TId>(DbModelBuilder modelBuilder, ref int order, Func<int, int> injectedPropertyDefs = null)
            where T : class, IHasKey, IHasDisplayableReferenceData, IHasTenantFK, IHasId<TId>, IHasTimestamp, IHasInRecordAuditability, IHasRecordState
            where TId: struct
        {
            modelBuilder.DefineTenantFK<T>(ref order);

            modelBuilder.DefineCustomId<T, TId>(ref order);

            modelBuilder.DefineKey<T>(ref order);

            modelBuilder.DefineTimestampedAuditedRecordStated<T>(ref order);

            modelBuilder.DefineDisplayableReferenceData<T>(ref order);







        }
    }
}