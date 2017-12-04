
namespace App.Core.Shared.Models.Entities.Base
{
    using System;
    using App.Core.Shared.Factories;

    public abstract class UntenantedGuidIdReferenceDataBase :
        UntenantedTimestampedAuditedRecordStatedGuidIdEntityBase, 
        IHasEnabled,
        IHasText,
        IHasDisplayOrderHint
    {
        protected UntenantedGuidIdReferenceDataBase()
        {
            Id = GuidFactory.NewGuid();
        }



        public virtual bool Enabled { get; set; }

        public virtual string Text { get; set; }

        /// <summary>
        /// Higher numbers are displayed at top.
        /// </summary>
        public virtual int DisplayOrderHint { get; set; }

        // A convention based hint as to display (could be a class name, or icon, CSV or both, DSL, etc.)
        public virtual string DisplayStyleHint { get; set; }
    }
}
