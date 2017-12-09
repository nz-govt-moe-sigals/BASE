using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Shared.Models.Messages.BaseClasses
{
    using App.Core.Shared.Factories;
    using App.Core.Shared.Models.Entities;

    public abstract class ReferenceDtoBase  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId, IHasTenantFK, IHasRecordState
    {
        protected ReferenceDtoBase()
        {
            this.Id = GuidFactory.NewGuid();
        }

        public virtual string Text { get; set; }
        public virtual Guid Id { get; set; }
        public virtual RecordPersistenceState RecordState { get; set; }
        public virtual Guid TenantFK { get; set; }
    }
}
