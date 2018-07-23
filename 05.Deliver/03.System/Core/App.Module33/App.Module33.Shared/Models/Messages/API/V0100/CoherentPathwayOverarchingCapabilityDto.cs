using System;
using App.Core.Shared.Attributes;
using App.Core.Shared.Factories;
using App.Core.Shared.Models;

namespace App.Module33.Shared.Models.Messages.API.V0100
{
    public class CoherentPathwayOverarchingCapabilityDto  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId
    {
        public CoherentPathwayOverarchingCapabilityDto()
        {
            this.Id = GuidFactory.NewGuid();
        }

        public Guid Id { get; set; }

        public bool Enabled { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int DisplayOrderHint { get; set; }

        public string DisplayStyleHint { get; set; }
    }
}

