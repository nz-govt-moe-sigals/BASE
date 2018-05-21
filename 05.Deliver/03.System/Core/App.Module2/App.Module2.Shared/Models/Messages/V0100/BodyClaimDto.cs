namespace App.Module02.Shared.Models.Messages.V0100
{
    using System;
    using App.Core.Shared.Factories;
    using App.Core.Shared.Models;
    using App.Core.Shared.Models.Entities;

    public class BodyClaimDto  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId, IHasTenantFK, IHasRecordState
    {
        public BodyClaimDto()
        {
            this.Id = GuidFactory.NewGuid();
        }

        public virtual Guid BodyFK { get; set; }
        public virtual string AuthorityKey { get; set; }
        public virtual string Key { get; set; }
        public virtual string Value { get; set; }
        public virtual string Signature { get; set; }
        public virtual Guid Id { get; set; }
        public virtual RecordPersistenceState RecordState { get; set; }
        public virtual Guid TenantFK { get; set; }
    }
}