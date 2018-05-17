namespace App.Core.Infrastructure.Db.Schema.Conventions
{
    using System;
    using System.Data.Entity;
    using App.Core.Shared.Models;



    public class  TenantFKAuditedRecordStatedTimestampedNoIdDataConvention
    {

        public virtual void Define<T>(DbModelBuilder modelBuilder, ref int order, Func<int, int> injectedPropertyDefs = null)
            where T : class, IHasTenantFK, IHasTimestamp, IHasInRecordAuditability, IHasRecordState
        {
            modelBuilder.DefineTenantFK<T>(ref order);

            //ID should go up here.... But will be before.

            modelBuilder.DefineTimestampedAuditedRecordStated<T>(ref order, injectedPropertyDefs);

        }
    }

}