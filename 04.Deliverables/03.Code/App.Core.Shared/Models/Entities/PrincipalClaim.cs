namespace App.Core.Shared.Models.Entities
{
    using System;

    public class PrincipalClaim : UntenantedTimestampedAuditedRecordStatedGuidIdEntityBase, IHasRecordState, IHasOwnerFK
    {
        public virtual string Authority { get; set; }
        public virtual string AuthoritySignature { get; set; }
        public virtual string Key { get; set; }
        public virtual string Value { get; set; }
        public virtual Guid OwnerFK { get; set; }
        //public virtual RecordPersistenceState RecordState { get; set; }


    }
}