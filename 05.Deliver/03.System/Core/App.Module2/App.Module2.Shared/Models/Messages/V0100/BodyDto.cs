namespace App.Module02.Shared.Models.Messages.V0100
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using App.Core.Shared.Factories;
    using App.Core.Shared.Models;
    using App.Core.Shared.Models.Entities;
    using App.Module02.Shared.Models.Entities;

    public class BodyDto  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId, IHasTenantFK, IHasRecordState
    {

        public BodyDto()
        {
            this.Id = GuidFactory.NewGuid();
        }
        public virtual RecordPersistenceState RecordState { get; set; }
        public virtual Guid TenantFK { get; set; }

        public virtual BodyType Type { get; set; }

        public virtual string Key { get; set; }

        public virtual BodyCategoryDto Category { get; set; }

        public virtual BodyLocationDto Location { get; set; }

        //public Guid PreferredNameFK { get; set; }
        //public BodyNameDto PreferredName { get; set; }

        // Display if Type=Organisation
        public virtual string Name { get; set; }

        public virtual string Prefix { get; set; }
        public virtual string GivenName { get; set; }
        public virtual string MiddleNames { get; set; }
        public virtual string SurName { get; set; }
        public virtual string Suffix { get; set; }


        public virtual ICollection<BodyAliasDto> Names
        {
            get
            {
                if (this._names == null)
                {
                    this._names = new Collection<BodyAliasDto>();
                }
                return this._names;
            }
            set => this._names = value;
        }
        private ICollection<BodyAliasDto> _names;

        public virtual ICollection<BodyChannelDto> Channels
        {
            get
            {
                if (this._channels == null)
                {
                    this._channels = new Collection<BodyChannelDto>();
                }
                return this._channels;
            }
            set => this._channels = value;
        }
        private ICollection<BodyChannelDto> _channels;

        public virtual ICollection<BodyPropertyDto> Properties
        {
            get
            {
                if (this._properties == null)
                {
                    this._properties = new Collection<BodyPropertyDto>();
                }
                return this._properties;
            }
            set => this._properties = value;
        }
        private ICollection<BodyClaimDto> _claims;

        public virtual ICollection<BodyClaimDto> Claims
        {
            get
            {
                if (this._claims == null)
                {
                    this._claims = new Collection<BodyClaimDto>();
                }
                return this._claims;
            }
            set => this._claims = value;
        }
        private ICollection<BodyPropertyDto> _properties;

        public virtual Guid Id { get; set; }

    }
}