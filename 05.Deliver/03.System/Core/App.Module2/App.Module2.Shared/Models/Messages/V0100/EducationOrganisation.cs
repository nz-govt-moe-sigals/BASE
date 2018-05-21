namespace App.Module02.Shared.Models.Entities
{
    using System;
    using App.Core.Shared.Factories;
    using App.Core.Shared.Models;
    using App.Module02.Shared.Models.Messages.V0100;

    public class EducationOrganisationDto  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId
    {
        public EducationOrganisationDto()
        {
            this.Id = GuidFactory.NewGuid();
        }

        public virtual Guid Id { get; set; }

        public virtual SchoolEstablishmentType Type { get; set; }

        public virtual string Key { get; set; }
        public virtual string Description { get; set; }

        public virtual BodyDto Organisation { get; set; }

        public virtual BodyDto Principal { get; set; }

        public virtual string Note { get; set; }
    }
}