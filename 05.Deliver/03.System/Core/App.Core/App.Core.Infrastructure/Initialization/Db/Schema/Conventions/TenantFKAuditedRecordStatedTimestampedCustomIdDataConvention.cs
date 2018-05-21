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
    /// <seealso cref="App.Core.Infrastructure.Db.Schema.Conventions.UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention" />
    public class TenantFKAuditedRecordStatedTimestampedCustomIdDataConvention
    {
        public void Define<T, TId>(DbModelBuilder modelBuilder, ref int order, Func<int, int> injectedPropertyDefs = null)
            where T : class, IHasTenantFK, IHasId<TId>, IHasTimestamp, IHasInRecordAuditability, IHasRecordState
            where TId : struct
        {

            modelBuilder.DefineTenantFK<T>(ref order);

            modelBuilder.DefineCustomId<T, TId>(ref order);

            modelBuilder.DefineTimestampedAuditedRecordStated<T>(ref order);


        }
    }
}