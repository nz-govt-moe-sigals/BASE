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
    public class TenantedSourceSystemKeyedGuidIdReferenceDataConvention : TenantedReferenceDataConvention
    {
        public new void Define<T>(DbModelBuilder modelBuilder, ref int order,
            Func<int, int> injectedPropertyDefs = null)
            where T : SourceSystemKeyedTenantedGuidIdReferenceDataBase
        {

            string typeName = typeof(T).Name;

            // Call underlying method first:
            base.Define<T>(modelBuilder, ref order, o =>
            {
                if (o != 11)
                {
                    return o;
                }


                modelBuilder.Entity<T>()
                    .Property(x => x.SourceSystemKey)
                    .HasColumnOrder(o++)
                    .HasMaxLength(TextFieldSizes.X10)
                    .HasColumnAnnotation("Index",
                        new IndexAnnotation(new IndexAttribute($"IX_{typeName}_FIRSTKey")
                        {
                            IsUnique = true
                        }))
                    .IsRequired();

                if (injectedPropertyDefs != null)
                {
                    o = injectedPropertyDefs.Invoke(o);
                }

                return o;
            });
        }
    }
}
