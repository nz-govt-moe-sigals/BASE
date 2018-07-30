namespace App.Core.Shared.Models.Entities.TenancySpecific
{
    using System;

    public class PrincipalProfileClaim : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase, IHasRecordState, IHasOwnerFK
    {
        public virtual string Authority { get; set; }
        public virtual string AuthoritySignature { get; set; }
        public virtual string Key { get; set; }
        public virtual string Value { get; set; }
        public virtual Guid PrincipalProfileFK { get; set; }
        //public virtual RecordPersistenceState RecordState { get; set; }


        public Guid GetOwnerFk()
        {
            return PrincipalProfileFK;
        }
    }
}