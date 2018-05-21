namespace App.Module11.Shared.Models.Messages.APIs.MOE.V0100.Base
{
    using System;
    using App.Core.Shared.Models;
    using App.Core.Shared.Models.Entities;
    using App.Module11.Shared.Models.Entities;

    public abstract class TenantedMOEReferenceDtoBase  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasId<int>, IHasTenantFK, IHasRecordState, IHasFIRSTKeyAsId
    {
        protected TenantedMOEReferenceDtoBase()
        {
            //this.Id = GuidFactory.NewGuid();
        }

        /// <summary>
        /// Gets or sets the MOE/FIRST ID
        /// <para>
        /// Decorating this property with [JsonProperty(PropertyName = "id")]
        /// This is needed for entities that will be persisted using DocumentDB.
        /// I'm so far resisting putting a reference on Newtonsoft's library, because
        /// it would cause all downstream assemblies to Reference this lib. Not good practices
        /// if it can be avoided.
        /// IH
        /// </para>
        /// </summary>
        public int Id
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
