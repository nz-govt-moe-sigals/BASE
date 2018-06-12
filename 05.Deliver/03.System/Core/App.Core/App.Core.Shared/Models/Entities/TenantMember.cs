namespace App.Core.Shared.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class TenantMember : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase, IHasEnabled {

        public DateTime? EnabledBeginningUtc { get; set; }
        public DateTime? EnabledEndingUtc { get; set; }
        public virtual bool Enabled { get; set; }

        public virtual string DisplayName { get; set; }

        public virtual NZDataClassification? DataClassificationFK { get; set; }
        public virtual DataClassification DataClassification { get; set; }

        public virtual TenantMemberCategory Category { get; set; }
        public virtual Guid CategoryFK { get; set; }


        public virtual ICollection<TenantMemberTag> Tags
        {
            get
            {
                if (this._tags == null)
                {
                    this._tags = new Collection<TenantMemberTag>();
                }
                return this._tags;
            }
            set => this._tags = value;
        }
        private ICollection<TenantMemberTag> _tags;





        public virtual ICollection<TenantMemberProperty> Properties
        {
            get
            {
                if (this._properties == null)
                {
                    this._properties = new Collection<TenantMemberProperty>();
                }
                return this._properties;
            }
            set => this._properties = value;
        }
        private ICollection<TenantMemberProperty> _properties;

        public virtual ICollection<TenantMemberClaim> Claims
        {
            get
            {
                if (this._claims == null)
                {
                    this._claims = new Collection<TenantMemberClaim>();
                }
                return this._claims;
            }
            set => this._claims = value;
        }
        private ICollection<TenantMemberClaim> _claims;





    }
}