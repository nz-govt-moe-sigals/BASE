using System;
using App.Core.Shared.Models.Entities;

namespace App.Module32.Shared.Models.Entities
{
    public class ExtractWatermark : UntenantedAuditedRecordStatedTimestampedGuidIdEntityBase
    {
        /// <summary>
        /// The Table Name that is required to be updated
        /// </summary>
        public string SourceTableName { get; set; }

        /// <summary>
        /// The last (UTC) updated time
        /// </summary>
        public DateTime Watermark { get; set; }
    }
}
