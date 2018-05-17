namespace App.Core.Shared.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    // It's *not* called User because a security Principal can be a User, but also a Device or Service.
    public class Principal : UntenantedAuditedRecordStatedTimestampedGuidIdEntityBase, IHasEnabled
    {
        public DateTime? EnabledBeginningUtc { get; set; }
        public DateTime? EnabledEndingUtc { get; set; }
        public virtual bool Enabled { get; set; }


        public virtual string DisplayName { get; set; }

        public virtual NZDataClassification? DataClassificationFK { get; set; }
        public virtual DataClassification DataClassification { get; set; }

        public virtual PrincipalCategory Category { get; set; }
        public virtual Guid CategoryFK { get; set; }

        public virtual ICollection<PrincipalTag> Tags
        {
            get
            {
                if (this._tags == null)
                {
                    this._tags = new Collection<PrincipalTag>();
                }
                return this._tags;
            }
            set => this._tags = value;
        }
        private ICollection<PrincipalTag> _tags;





        public virtual ICollection<PrincipalProperty> Properties
        {
            get
            {
                if (this._properties == null)
                {
                    this._properties = new Collection<PrincipalProperty>();
                }
                return this._properties;
            }
            set => this._properties = value;
        }
        private ICollection<PrincipalProperty> _properties;

        public virtual ICollection<PrincipalClaim> Claims
        {
            get
            {
                if (this._claims == null)
                {
                    this._claims = new Collection<PrincipalClaim>();
                }
                return this._claims;
            }
            set => this._claims = value;
        }
        private ICollection<PrincipalClaim> _claims;



        public virtual ICollection<PrincipalLogin> Logins
        {
            get
            {
                if (this._logins == null)
                {
                    this._logins = new Collection<PrincipalLogin>();
                }
                return this._logins;
            }
            set => this._logins = value;
        }
        private ICollection<PrincipalLogin> _logins;


        public virtual ICollection<SystemRole> Roles
        {
            get
            {
                if (this._roles == null)
                {
                    this._roles = new Collection<SystemRole>();
                }
                return this._roles;
            }
            set => this._roles = value;
        }
        private ICollection<SystemRole> _roles;

    }
}