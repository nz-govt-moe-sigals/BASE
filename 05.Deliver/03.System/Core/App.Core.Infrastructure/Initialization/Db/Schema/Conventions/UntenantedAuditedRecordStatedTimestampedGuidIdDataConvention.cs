namespace App.Core.Infrastructure.Db.Schema.Conventions
{
    using System;
    using System.Data.Entity;
    using App.Core.Shared.Models;
    using App.Core.Shared.Models.Entities;

    public class UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention
    {
        public virtual void Define<T>(DbModelBuilder modelBuilder, ref int order, Func<int, int> injectedPropertyDefs = null)
            where T : class, IHasGuidId, IHasId<Guid>, IHasTimestamp, IHasInRecordAuditability, IHasRecordState
        {

            modelBuilder.DefineCustomId<T, Guid>(ref order);

            modelBuilder.DefineTimestampedAuditedRecordStated<T>(ref order);


        }
    }

}