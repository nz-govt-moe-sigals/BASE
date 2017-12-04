namespace App.Module2.Shared.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using App.Core.Shared.Models.Entities;
    using App.Module2.Shared.Models.Messages.V0100;

    // Should be wary of enums, but this will do for a demo

    public class Body : TenantFKTimestampedAuditedRecordStatedGuidIdEntityBase
    {
    

        public BodyType Type { get; set; }

        /// <summary>
        ///     Optional unique Key.
        /// </summary>
        public virtual string Key { get; set; }

        public virtual Guid CategoryFK { get; set; }
        public virtual BodyCategory Category { get; set; }


        public virtual Guid? LocationFK { get; set; }
        public virtual BodyLocation Location { get; set; }

        // Display if Type=Organisation
        public virtual string Name { get; set; }

        public virtual string Prefix { get; set; }
        public virtual string GivenName { get; set; }
        public virtual string MiddleNames { get; set; }
        public virtual string SurName { get; set; }
        public virtual string Suffix { get; set; }

        public virtual ICollection<BodyAlias> Aliases
        {
            get
            {
                if (this._aliases == null)
                {
                    this._aliases = new Collection<BodyAlias>();
                }
                return this._aliases;
            }
        }
        private ICollection<BodyAlias> _aliases;

        // A Body can be contacted by many different types of channels:
        public virtual ICollection<BodyChannel> Channels
        {
            get
            {
                if (this._channels == null)
                {
                    this._channels = new Collection<BodyChannel>();
                }
                return this._channels;
            }
        }
        private ICollection<BodyChannel> _channels;

        public virtual ICollection<BodyProperty> Properties
        {
            get
            {
                if (this._properties == null)
                {
                    this._properties = new Collection<BodyProperty>();
                }
                return this._properties;
            }
            set => this._properties = value;
        }
        private ICollection<BodyProperty> _properties;

        public virtual ICollection<BodyClaim> Claims
        {
            get
            {
                if (this._claims == null)
                {
                    this._claims = new Collection<BodyClaim>();
                }
                return this._claims;
            }
            set => this._claims = value;
        }
        private ICollection<BodyClaim> _claims;
        

        public virtual string Description { get; set; }
        public virtual string Notes { get; set; }
    }
}