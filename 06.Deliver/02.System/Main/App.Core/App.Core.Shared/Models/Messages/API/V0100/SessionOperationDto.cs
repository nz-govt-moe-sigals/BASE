namespace App.Core.Shared.Models.Messages.API.V0100
{
    using System;

    public class SessionOperationDto  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId
    {
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

        public virtual Guid Id { get; set; }

    }
}