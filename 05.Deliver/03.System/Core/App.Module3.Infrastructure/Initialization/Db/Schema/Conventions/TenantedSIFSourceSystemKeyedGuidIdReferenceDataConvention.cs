


namespace App.Module3.Infrastructure.Db.Schema.Conventions
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure.Annotations;
    using App.Core.Infrastructure.Constants.Db;
    using App.Core.Shared.Models.Entities.Base;
    using App.Module3.Shared.Models.Entities;

    public class TenantedSIFSourceSystemKeyedGuidIdReferenceDataConvention 
    {


        public void Define<T>(DbModelBuilder modelBuilder, ref int order,
            Func<int, int> injectedPropertyDefs = null)
            where T : SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase
        {

            modelBuilder.DefineTenantFK<T>(ref order);

            modelBuilder.DefineCustomId<T, Guid>(ref order);

            modelBuilder.DefineSourceSystemFields<T>(ref order);

            modelBuilder.DefineSIFFields<T>(ref order);

            modelBuilder.DefineTimestampedAuditedRecordStated<T>(ref order);

            modelBuilder.DefineDisplayableReferenceData<T>(ref order);

        }

    }
}