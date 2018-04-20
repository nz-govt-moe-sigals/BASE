using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module3.Shared.Models.Messages.APIs.V0100
{
    using App.Core.Shared.Models;
    using App.Core.Shared.Models.Entities;
    using App.Module3.Shared.Models.Entities;

    public abstract class TenantedSIFReferenceDtoBase  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasId<string>, IHasTenantFK, IHasRecordState,
        IHasSIFIdAsStringId
    {
        protected TenantedSIFReferenceDtoBase()
        {
            //this.Id = GuidFactory.NewGuid();
        }

        public virtual string Id
        {
            get; set;
        }
        public virtual RecordPersistenceState RecordState
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
