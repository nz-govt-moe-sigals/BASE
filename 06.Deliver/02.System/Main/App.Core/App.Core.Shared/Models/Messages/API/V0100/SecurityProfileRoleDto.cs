namespace App.Core.Shared.Models.Messages.API.V0100
{
    using System;
    using System.Collections.Generic;
    using App.Core.Shared.Factories;
    using App.Core.Shared.Models;

    public class SecurityProfileRoleDto  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId
    {
        public SecurityProfileRoleDto()
        {
            this.Id = GuidFactory.NewGuid();

        }

        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<SecurityProfilePermissionDto> Permissions { get; set; }

    }
}

