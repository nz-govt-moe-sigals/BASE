namespace App.Core.Shared.Models.Entities.Base
{
    public abstract class TenantedCustomIdReferenceDataBase<TId> : TenantFkTimestampedAuditedRecordStatedCustomIdEntityBase<TId>,
        IHasEnabled,
        IHasText,
        IHasDisplayOrderHint
    {


        public virtual  bool Enabled { get; set; }

        public virtual string Text { get; set; }

        public virtual int DisplayOrderHint { get; set; }

        // A convention based hint as to display (could be a class name, or icon, CSV or both, DSL, etc.)
        public virtual string DisplayStyleHint { get; set; }
    }
}