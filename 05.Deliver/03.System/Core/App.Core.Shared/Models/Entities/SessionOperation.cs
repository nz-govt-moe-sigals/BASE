namespace App.Core.Shared.Models.Entities
{
    using System;

    public class SessionOperation : UntenantedTimestampedAuditedRecordStatedGuidIdEntityBase, IHasOwnerFK
    {
        // A Session Operation is bound to a Session
        // Which is bound to a Principal, but not a Tenant
        public virtual Guid OwnerFK { get; set; }

        public virtual string ClientIp { get; set; }
        public virtual string Url { get; set; }
        public virtual string ResourceTenantKey { get; set; }
        public virtual string ControllerName { get; set; }
        public virtual string ActionName { get; set; }
        public virtual string ActionArguments { get; set; }
        public virtual DateTimeOffset BeginDateTimeUtc { get; set; }
        public virtual DateTimeOffset EndDateTimeUtc { get; set; }
        public virtual TimeSpan Duration { get; set; }
        public virtual string ResponseCode { get; set; }


    }
}