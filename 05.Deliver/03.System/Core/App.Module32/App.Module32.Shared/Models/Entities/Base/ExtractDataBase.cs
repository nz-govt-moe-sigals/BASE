using System;
using App.Core.Shared.Models.Entities;

namespace App.Module32.Shared.Models.Entities
{
    public abstract class ExtractDataBase : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase
    {
        protected ExtractDataBase()
        {
            SourceModifiedDate = DateTime.UtcNow;
        }

        public DateTime? SourceModifiedDate { get; set; }
    }
}
