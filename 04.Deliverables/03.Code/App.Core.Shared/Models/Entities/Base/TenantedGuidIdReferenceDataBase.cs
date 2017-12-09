namespace App.Core.Shared.Models.Entities.Base
{
    using System;
    using App.Core.Shared.Factories;

    public abstract class KeyedTenantedGuidIdReferenceDataBase : TenantedGuidIdReferenceDataBase
    {
    }


    public abstract class TenantedGuidIdReferenceDataBase :TenantFKTimestampedAuditedRecordStatedGuidIdEntityBase,
        IHasEnabled,
        IHasText,
        IHasDisplayOrderHint
    {

        public virtual bool Enabled { get; set; }

        public virtual string Text { get; set; }

        public virtual int DisplayOrderHint { get; set; }

        // A convention based hint as to display (could be a class name, or icon, CSV or both, DSL, etc.)
        public virtual string DisplayStyleHint { get; set; }


        protected TenantedGuidIdReferenceDataBase()
                {
                    Id = GuidFactory.NewGuid();
                }



    }
}