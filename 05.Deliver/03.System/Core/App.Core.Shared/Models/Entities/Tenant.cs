namespace App.Core.Shared.Models.Entities
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class Tenant : UntenantedTimestampedAuditedRecordStatedGuidIdEntityBase, IHasKey, IHasEnabled
    {
        private ICollection<TenantClaim> _claims;
        private ICollection<TenantProperty> _properties;

        /// <summary>
        ///     Only one Tenant can be marked as Default.
        /// </summary>
        public virtual bool? IsDefault { get; set; }

        /// <summary>
        ///     The hostname or key to match on.
        ///     <para>
        ///         Valid entries might be 'org1.service.tld' or 'org1.tld', or 'localhost:43311' (but I don't recommend the use
        ///         of ports)
        ///     </para>
        /// </summary>
        public virtual string HostName { get; set; }

        public virtual string DisplayName { get; set; }

        public virtual NZDataClassification? DataClassificationFK { get; set; }
        public virtual DataClassification DataClassification { get; set; }

        public virtual ICollection<TenantProperty> Properties
        {
            get => this._properties ?? (this._properties = new Collection<TenantProperty>());
            set => this._properties = value;
        }

        public virtual ICollection<TenantClaim> Claims
        {
            get
            {
                if (this._claims == null)
                {
                    this._claims = new Collection<TenantClaim>();
                }
                return this._claims;
            }
            set => this._claims = value;
        }

        public virtual bool Enabled { get; set; }

        public virtual string Key { get; set; }
    }
}