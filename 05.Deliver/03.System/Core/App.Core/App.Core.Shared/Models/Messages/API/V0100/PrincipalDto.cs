namespace App.Core.Shared.Models.Messages.API.V0100
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;



    public class PrincipalDto  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId, IHasEnabled
    {
        private ICollection<PrincipalClaimDto> _claims;
        private ICollection<PrincipalPropertyDto> _properties;
        private ICollection<PrincipalTagDto> _tags;
        private ICollection<PrincipalLoginDto> _logins;
        private ICollection<RoleDto> _roles;

        public virtual string DisplayName { get; set; }

        public DataClassificationDto DataClassification { get; set; }

        public PrincipalCategoryDto Category { get; set; }


        public ICollection<RoleDto> Roles
        {
            get
            {
                if (this._roles == null)
                {
                    this._roles = new Collection<RoleDto>();
                }
                return this._roles;
            }
            set => this._roles = value;
        }

        public ICollection<PrincipalLoginDto> Logins
        {
            get
            {
                if (this._logins == null)
                {
                    this._logins = new Collection<PrincipalLoginDto>();
                }
                return this._logins;
            }
            set => this._logins = value;
        }

        public virtual ICollection<PrincipalTagDto> Tags
        {
            get
            {
                if (this._tags == null)
                {
                    this._tags = new Collection<PrincipalTagDto>();
                }
                return this._tags;
            }
            set => this._tags = value;
        }
        
        public virtual ICollection<PrincipalPropertyDto> Properties
        {
            get
            {
                if (this._properties == null)
                {
                    this._properties = new Collection<PrincipalPropertyDto>();
                }
                return this._properties;
            }
            set => this._properties = value;
        }
        

        public virtual ICollection<PrincipalClaimDto> Claims
        {
            get
            {
                if (this._claims == null)
                {
                    this._claims = new Collection<PrincipalClaimDto>();
                }
                return this._claims;
            }
            set => this._claims = value;
        }
      

        public virtual bool Enabled { get; set; }
        public virtual Guid Id { get; set; }
    }
}