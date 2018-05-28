namespace App.Core.Shared.Models.Messages.API.V0100
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;



    public class PrincipalDto  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId, IHasEnabled
    {
        public virtual string DisplayName { get; set; }

        public DataClassificationDto DataClassification { get; set; }

        public PrincipalCategoryDto Category { get; set; }

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
        private ICollection<PrincipalTagDto> _tags;



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
        private ICollection<PrincipalPropertyDto> _properties;

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
        private ICollection<PrincipalClaimDto> _claims;

        public virtual bool Enabled { get; set; }
        public virtual Guid Id { get; set; }
    }
}