using App.Core.Shared.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module3.Shared.Models.Entities
{
    public class ExtractWatermark : UntenantedTimestampedAuditedRecordStatedGuidIdEntityBase
    {
        /// <summary>
        /// The Table Name that is required to be updated
        /// </summary>
        public string SourceTableName { get; set; }

        /// <summary>
        /// The last updated time
        /// </summary>
        public DateTime Watermark {get; set;}
    }
}
