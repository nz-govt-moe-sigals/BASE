using System;
using App.Core.Shared.Models.Entities;

namespace App.Module32.Shared.Models.Entities
{
    public abstract class ExtractDataBase : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase
    {
        public DateTime? SourceModifiedDate { get; set; }
    }
}
