namespace App.Core.Shared.Models.Messages.APIs.V0100
{
    using System;
    using App.Core.Shared.Models.Entities;

    public class TenantPropertyDto  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId, IHasTenantFK, IHasRecordState
    {
        public virtual string Key { get; set; }
        public virtual string Value { get; set; }
        public virtual Guid Id { get; set; }
        public virtual RecordPersistenceState RecordState { get; set; }
        public virtual Guid TenantFK { get; set; }
    }
}