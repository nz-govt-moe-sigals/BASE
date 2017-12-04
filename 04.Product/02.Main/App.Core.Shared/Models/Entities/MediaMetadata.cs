namespace App.Core.Shared.Models.Entities
{
    using System;

    public class MediaMetadata : TenantFKTimestampedAuditedRecordStatedGuidIdEntityBase
    {
        // Use an Enum as DataClassification is shared across Bounded DbContexts
        public virtual NZDataClassification DataClassificationFK {get; set;} /* Unclassified or not determines whether external scanning services can be invoked or not */
        public virtual DataClassification DataClassification {get; set;}
        public virtual DateTime UploadedDateTimeUtc { get; set; }
        public virtual long ContentSize { get; set; } /*size of stream*/
        public virtual string MimeType { get; set; } /*The extension is not always a correct indicator...*/
        public virtual string SourceFileName { get; set; } /*the name the file had on the uploader's machine*/
        public virtual string ContentHash { get; set; } /*unique hash of the stream for faster reference later*/

        public virtual string LocalName { get; set; } /*name in storage container*/

        // Results of scanning, whenever done:
        public virtual DateTime? LatestScanDateTimeUtc { get; set; } /*can be scanned regularly*/

        public virtual bool? LatestScanMalwareDetetected { get; set; }
        public virtual string LatestScanResults { get; set; }
    }
}