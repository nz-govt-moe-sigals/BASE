namespace App.Core.Shared.Models.Entities.TenancySpecific
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
     
    public class PrincipalProfile : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase, IHasEnabled {

        public DateTime? EnabledBeginningUtc { get; set; }
        public DateTime? EnabledEndingUtc { get; set; }
        public virtual bool Enabled { get; set; }

        public virtual string DisplayName { get; set; }

        public virtual NZDataClassification? DataClassificationFK { get; set; }
        public virtual DataClassification DataClassification { get; set; }

        public virtual PrincipalProfileCategory Category { get; set; }
        public virtual Guid CategoryFK { get; set; }


        public virtual ICollection<PrincipalProfileTag> Tags
        {
            get
            {
                if (this._tags == null)
                {
                    this._tags = new Collection<PrincipalProfileTag>();
                }
                return this._tags;
            }
            set => this._tags = value;
        }
        private ICollection<PrincipalProfileTag> _tags;





        public virtual ICollection<PrincipalProfileProperty> Properties
        {
            get
            {
                if (this._properties == null)
                {
                    this._properties = new Collection<PrincipalProfileProperty>();
                }
                return this._properties;
            }
            set => this._properties = value;
        }
        private ICollection<PrincipalProfileProperty> _properties;

        public virtual ICollection<PrincipalProfileClaim> Claims
        {
            get
            {
                if (this._claims == null)
                {
                    this._claims = new Collection<PrincipalProfileClaim>();
                }
                return this._claims;
            }
            set => this._claims = value;
        }
        private ICollection<PrincipalProfileClaim> _claims;





    }
}