using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Shared.Models.Messages.BaseClasses
{
    using App.Core.Shared.Factories;
    using App.Core.Shared.Models.Entities;

    public abstract class TenantedRecordStateGuidIdReferenceDtoBase  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : TenantedRecordStateGuidIdDtoBase
    {
        protected TenantedRecordStateGuidIdReferenceDtoBase(): base()
        {
            //this.Id = GuidFactory.NewGuid();
        }

        public virtual string Text { get; set; }
    }


    public abstract class TenantedRecordStateGuidIdDtoBase : /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ TenantedRecordStatedDtoBase, IHasGuidId
    {
        protected TenantedRecordStateGuidIdDtoBase()
        {
            this.Id = GuidFactory.NewGuid();
        }

        public virtual Guid Id
        {
            get; set;
        }
    }

    public abstract class TenantedRecordStatedDtoBase : /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ IHasTenantFK, IHasRecordState
    {
        public virtual RecordPersistenceState RecordState
        {
            get; set;
        }

        public virtual Guid TenantFK
        {
            get; set;
        }
    }

}
