namespace App.Module3.Shared.Models.Messages.APIs.SIF.V0100.Base
{
    using System;
    using App.Core.Shared.Models;
    using App.Core.Shared.Models.Entities;
    using App.Module3.Shared.Models.Entities;

    public abstract class TenantedSIFReferenceDtoBase  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasId<string>, IHasTenantFK, IHasSIFIdAsStringId
    {
        protected TenantedSIFReferenceDtoBase()
        {
            //this.Id = GuidFactory.NewGuid();
        }

        public virtual string Id
        {
            get; set;
        }
        public virtual Guid TenantFK
        {
            get; set;
        }
        public virtual string Text
        {
            get; set;
        }

    }

}
