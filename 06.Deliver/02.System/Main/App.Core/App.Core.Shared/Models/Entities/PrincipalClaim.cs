﻿namespace App.Core.Shared.Models.Entities
{
    using System;

    public class PrincipalClaim : UntenantedAuditedRecordStatedTimestampedGuidIdEntityBase, IHasRecordState, IHasOwnerFK, IHasKeyValue<string>
    {
        public virtual string Authority { get; set; }
        public virtual string AuthoritySignature { get; set; }
        public virtual string Key { get; set; }
        public virtual string Value { get; set; }
        public virtual Guid PrincipalFK { get; set; }
        //public virtual RecordPersistenceState RecordState { get; set; }


        public Guid GetOwnerFk()
        {
            return PrincipalFK;
        }
    }
}