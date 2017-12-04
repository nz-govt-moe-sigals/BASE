namespace App.Core.Shared.Models.Entities
{
    using System;

    public class ExceptionRecord : UntenantedTimestampedAuditedRecordStatedGuidIdEntityBase
    {
        public TraceLevel Level { get; set; }
        public string Title { get; set; }
        public string Stack { get; set; }
    }
}
