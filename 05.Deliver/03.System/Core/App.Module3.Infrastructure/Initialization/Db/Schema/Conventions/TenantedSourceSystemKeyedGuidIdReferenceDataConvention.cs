using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Constants.Db;
using App.Core.Infrastructure.Db.Schema.Conventions;
using App.Module3.Shared.Models.Entities;

namespace App.Module3.Infrastructure.Db.Schema.Conventions
{
    
    public class TenantedSourceSystemKeyedGuidIdReferenceDataConvention 
    {
        public void Define<T>(DbModelBuilder modelBuilder, ref int order,
            Func<int, int> injectedPropertyDefs = null)
            where T : SourceSystemKeyedTenantedGuidIdReferenceDataBase
        {



            // Invoke Helpers:

            modelBuilder.DefineTenantFK<T>(ref order);

            modelBuilder.DefineCustomId<T, Guid>(ref order);

            modelBuilder.DefineSourceSystemFields<T>(ref order);

            modelBuilder.DefineTimestampedAuditedRecordStated<T>(ref order);

            modelBuilder.DefineDisplayableReferenceData<T>(ref order);


        }
    }
}
