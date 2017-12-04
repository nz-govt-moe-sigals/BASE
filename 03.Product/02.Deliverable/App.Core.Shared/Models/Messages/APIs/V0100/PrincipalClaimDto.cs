namespace App.Core.Shared.Models.Messages.APIs.V0100
{
    using System;
    using App.Core.Shared.Models.Entities;

    public class PrincipalClaimDto  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId, IHasRecordState, IHasPrincipalFK, IHasKey, IHasValue<string>
    {
        public virtual string AuthorityKey { get; set; }
        public virtual string Signature { get; set; }
        public virtual Guid Id { get; set; }
        public virtual string Key { get; set; }

        public virtual Guid PrincipalFK { get; set; }
        public virtual RecordPersistenceState RecordState { get; set; }
        public virtual string Value { get; set; }
    }
}