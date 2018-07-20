using System;
using System.Collections.Generic;
using App.Core.Shared.Attributes;
using App.Core.Shared.Factories;
using App.Core.Shared.Models;

namespace App.Module33.Shared.Models.Messages.API.V0100
{
    public class CoherentPathwayDto  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId
    {
        public CoherentPathwayDto()
        {
            this.Id = GuidFactory.NewGuid();
        }

        public Guid Id { get; set; }

        public string Strategy { get; set; }

        public ICollection<CoherentPathwayStepDto> CoherentPathwaySteps { get; set; }
    }
}

