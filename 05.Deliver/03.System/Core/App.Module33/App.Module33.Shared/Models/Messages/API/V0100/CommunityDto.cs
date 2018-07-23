using System;
using System.Collections.Generic;
using App.Core.Shared.Attributes;
using App.Core.Shared.Factories;
using App.Core.Shared.Models;
using App.Module33.Shared.Models.Entities;

namespace App.Module33.Shared.Models.Messages.API.V0100
{
    public class CommunityDto  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId
    {
        public CommunityDto()
        {
            this.Id = GuidFactory.NewGuid();
        }

        public string PublicText { get; set; }

        [RoleSecuredDtoModelAttribute("veryspecialrole")]
        public string SensitiveText { get; set; }

        public Guid Id { get; set; }

        //No Private Text Field (ie, no mapping at all).

        public string Name { get; set; }

        public string Description { get; set; }

        public CommunityColourScheme ColourScheme { get; set; }

        public string Strategy { get; set; }

        public ICollection<CoherentPathwayDto> CoherentPathways { get; set; }
    }
}

