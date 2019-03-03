namespace App.Core.Infrastructure.Db.Schema.Conventions
{
    using System;
    using System.Data.Entity;
    using App.Core.Shared.Models;



    public class  UntenantedAuditedRecordStatedTimestampedNoIdDataConvention
    {

        public virtual void Define<T>(DbModelBuilder modelBuilder, ref int order, Func<int, int> injectedPropertyDefs = null)
            where T : class, IHasTimestamp, IHasInRecordAuditability, IHasRecordState
        {



            modelBuilder.DefineTimestampedAuditedRecordStated<T>(ref order, injectedPropertyDefs);

        }
    }

}