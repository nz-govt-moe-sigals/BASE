namespace App.Core.Shared.Models.Entities
{
    using System;

    /// <summary>
    ///     Optional attributes to associate to the
    ///     <see cref="PersistedMedia" />
    /// </summary>
    public class PersistedMediaProperty :
        TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase,
        IHasOwnerFK, IHasKeyValue<string>,
        IHasTag
    {
        /// <summary>
        ///     Gets or sets the key.
        ///     <para>Member defined in<see cref="IHasKey" /></para>
        /// </summary>
        public virtual string Key { get; set; }

        /// <summary>
        ///     Gets or sets the value.
        /// </summary>
        public virtual string Value { get; set; }


        /// <summary>
        ///     Gets or sets the Id of the
        ///     <see cref="PersistedMedia" />
        ///     that manages a collection of these
        ///     <see cref="PersistedMedia" />
        ///     attributes.
        /// </summary>
        public virtual Guid OwnerFK { get; set; }

        /// <summary>
        ///     Gets the tag of the object.
        ///     <para>Member defined in<see cref="XAct.IHasTag" /></para>
        ///     <para>Can be used to associate information -- such as an image ref -- to a SelectableItem.</para>
        /// </summary>
        public virtual string Tag { get; set; }
    }
}