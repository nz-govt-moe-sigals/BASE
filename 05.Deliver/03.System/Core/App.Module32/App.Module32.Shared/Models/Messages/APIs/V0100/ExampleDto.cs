namespace App.Core.Shared.Models.Messages.API.V0100
{
    using System;
    using App.Core.Shared.Attributes;
    using App.Core.Shared.Factories;

    public class ExampleDto  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId
    {
        public ExampleDto()
        {
            this.Id = GuidFactory.NewGuid();
        }

        public virtual string PublicText { get; set; }

        [RoleSecuredDtoModelAttribute("veryspecialrole")]
        public virtual string SensitiveText { get; set; }

        public virtual Guid Id { get; set; }

        //No Private Text Field (ie, no mapping at all).
    }
}

