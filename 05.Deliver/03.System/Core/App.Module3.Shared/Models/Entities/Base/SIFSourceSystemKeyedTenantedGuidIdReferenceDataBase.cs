

namespace App.Module3.Shared.Models.Entities
{
    using App.Core.Shared.Models.Entities.Base;

    /// <summary>
    /// Abstract base class 
    /// for System ReferenceData entities.
    /// <para>
    /// Key aspects that are common to all ReferenceData
    /// include 
    /// * the Source Id is persisted as the <see cref="Models.IHasSourceSystemKey.SourceSystemKey"/>
    /// * the Source Id is used to find and fill in the <see cref="IHasSIFKey.SIFKey"/> value.
    /// </para>
    /// </summary>
    /// <seealso cref="App.Core.Shared.Models.Entities.Base.TenantedGuidIdReferenceDataBase" />
    /// <seealso cref="App.Module3.Shared.Models.IHasSourceSystemKey" />
    /// <seealso cref="App.Module3.Shared.Models.IHasSIFKey" />
    // ReSharper disable once InconsistentNaming
    public class SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase : SourceSystemKeyedTenantedGuidIdReferenceDataBase, IHasSIFKey
    {
 

        /// <summary>
        /// Gets or sets the PK used by SIF API Messages.
        /// <para>
        /// The PK value is not always defined in the SIF.
        /// It can fall back to MOE values, which in turn
        /// are falling back to NZSTATS values.
        /// </para><para>
        /// The Type is String as the value
        /// can be a character (eg: Gender),
        /// a word, or an integer
        /// </para>
        /// </summary>
        public string SIFKey { get; set; }
    }
}
