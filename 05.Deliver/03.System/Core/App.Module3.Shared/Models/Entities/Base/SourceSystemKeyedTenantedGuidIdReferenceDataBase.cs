using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Shared.Models.Entities.Base;

namespace App.Module3.Shared.Models.Entities
{
    public class SourceSystemKeyedTenantedGuidIdReferenceDataBase : TenantFKAuditedRecordStatedTimestampedGuidIdReferenceDataEntityBase, Models.IHasSourceSystemKey 
    {
        /// <summary>
        /// Gets or sets the name of systme that provided
        /// the <see cref="SourceSystemKey" /> (eg: FIRST).
        /// </summary>
        public string SourceSystemName
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the source system (eg: MOE'S FIRST) defined key.
        /// <para>
        /// The type is string as not all source codes
        /// are integers (eg: LocalOffice is a string).
        /// </para>
        /// </summary>
        public string SourceSystemKey
        {
            get; set;
        }
    }
}
