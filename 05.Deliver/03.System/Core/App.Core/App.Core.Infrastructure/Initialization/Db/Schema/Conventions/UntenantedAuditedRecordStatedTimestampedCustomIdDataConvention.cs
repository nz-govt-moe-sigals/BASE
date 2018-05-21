namespace App.Core.Infrastructure.Db.Schema.Conventions
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using App.Core.Shared.Models;
    using App.Core.Shared.Models.Entities;

    public class UntenantedAuditedRecordStatedTimestampedCustomIdDataConvention
    {

        public virtual void Define<T,TId>(DbModelBuilder modelBuilder, ref int order, Func<int, int> injectedPropertyDefs = null)
            where T : class, IHasId<TId>, IHasTimestamp, IHasInRecordAuditability, IHasRecordState
            where TId: struct
        {
            modelBuilder.DefineCustomId<T, TId>(ref order);

            modelBuilder.DefineTimestampedAuditedRecordStated<T>(ref order);

        }
    }

}