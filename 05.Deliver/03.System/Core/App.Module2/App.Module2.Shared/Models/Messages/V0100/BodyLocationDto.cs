using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module02.Shared.Models.Messages.V0100
{
    using App.Core.Shared.Factories;
    using App.Core.Shared.Models;
    using App.Core.Shared.Models.Entities;

    public class BodyLocationDto /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId, IHasTenantFK, IHasRecordState
    {
        public BodyLocationDto()
        {
            this.Id = GuidFactory.NewGuid();
        }

        public virtual Guid Id { get; set; }
        public virtual Guid TenantFK { get; set; }
        public virtual RecordPersistenceState RecordState { get; set; }

        public virtual decimal Latitude { get; set; }
        public virtual decimal Longitude { get; set; }

    }
}
