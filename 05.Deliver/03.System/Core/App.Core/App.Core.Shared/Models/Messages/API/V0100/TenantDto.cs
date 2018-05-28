namespace App.Core.Shared.Models.Messages.API.V0100
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class TenantDto /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */  : IHasGuidId, IHasEnabled
    {

        public virtual Guid Id { get; set; }
        public virtual bool Enabled { get; set; }
        public virtual string Key { get; set; }
        public virtual string DisplayName { get; set; }

        public DataClassificationDto DataClassification { get; set; }

        public virtual ICollection<TenantPropertyDto> Properties
        {
            get
            {
                if (this._properties == null)
                {
                    this._properties = new Collection<TenantPropertyDto>();
                }
                return this._properties;
            }
            set => this._properties = value;
        }
        private ICollection<TenantPropertyDto> _properties;

        public virtual ICollection<TenantClaimDto> Claims
        {
            get
            {
                if (this._claims == null)
                {
                    this._claims = new Collection<TenantClaimDto>();
                }
                return this._claims;
            }
            set => this._claims = value;
        }
        private ICollection<TenantClaimDto> _claims;

    }
}