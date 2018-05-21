namespace App.Module02.Shared.Models.Messages.V0100
{
    using System;
    using App.Core.Shared.Factories;
    using App.Core.Shared.Models;
    using App.Core.Shared.Models.Entities;

    public class BodyAliasDto  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId, IHasTenantFK, IHasRecordState, IHasDisplayOrderHint
    {
        public BodyAliasDto()
        {
            this.Id = GuidFactory.NewGuid();
        }

        public virtual Guid Id { get; set; }
        public virtual Guid TenantFK { get; set; }
        public virtual RecordPersistenceState RecordState { get; set; }
        public virtual Guid BodyFK { get; set; }

        public virtual string Name { get; set; }

        public virtual string Prefix { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Suffix { get; set; }

        public virtual int DisplayOrderHint { get; set; }

    }
}