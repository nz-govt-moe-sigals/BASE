namespace App.Core.Infrastructure.Db.Schema.Conventions
{
    using System;
    using System.Data.Entity;
    using App.Core.Shared.Models;
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
    /// <seealso cref="App.Core.Infrastructure.Db.Schema.Conventions.TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention" />
    public class TenantFKAuditedRecordStatedTimestampedGuidIdReferenceDataConvention
    { 
        public void Define<T>(DbModelBuilder modelBuilder, ref int order, Func<int, int> injectedPropertyDefs =null)
            where T : class, IHasDisplayableReferenceData, IHasTenantFK, IHasGuidId, IHasId<Guid>, IHasTimestamp, IHasInRecordAuditability, IHasRecordState
        {
            modelBuilder.DefineTenantFK<T>(ref order);

            modelBuilder.DefineCustomId<T, Guid>(ref order);

            modelBuilder.DefineTimestampedAuditedRecordStated<T>(ref order);

            modelBuilder.DefineDisplayableReferenceData<T>(ref order);

        }
    }
}