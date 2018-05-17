namespace App.Core.Shared.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;


    /// <summary>
    /// <para>
    /// A Tenant is an Application Account.
    /// A Tenant/ApplicationAccount has 1+ UserAccounts/Principals
    /// An ApplicationAccount/Tenant 
    /// </para>
    /// </summary>
    public class Tenant : UntenantedAuditedRecordStatedTimestampedGuidIdEntityBase, IHasKey, IHasEnabled
    {

        /// <summary>
        /// Gets or sets whether the Account is enabled.
        /// </summary>
        public virtual bool Enabled { get; set; }


        ///// <summary>
        ///// The foreign key to the Subscription object
        ///// related to this Application Account/Tenancy.
        ///// <para>
        ///// The Subscription provides Access information (ie, Beginning/End dates, etc.)
        ///// to the logical Account/Tenancy.
        ///// </para>
        ///// </summary>
        //public Guid SubscriptionFK { get; set; }
        //public Subscription Subscription { get; set; }


        /// <summary>
        /// The key is unique, 
        /// and provides a human readable element 
        /// to paths.
        /// </summary>
        public virtual string Key { get; set; }


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
        private ICollection<TenantProperty> _properties;

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
        private ICollection<TenantClaim> _claims;

    }
}