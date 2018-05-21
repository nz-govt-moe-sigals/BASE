
namespace App.Module11.Shared.Models
{
    /// <summary>
    /// Contract for system entity objects
    /// that record a SIF API compatible Unique (Primary) Key.
    /// </summary>
    public interface IHasSIFKey
    {
        /// <summary>
        /// Gets or sets the PK used by SIF API Messages.
        /// <para>
        /// The PK value is not always defined in the SIF.
        /// It can fall back to MOE values, which in turn
        /// are falling back to NZSTATS values. 
        /// </para>
        /// <para>
        /// The Type is String as the value
        /// can be a character (eg: Gender), 
        /// a word, or an integer
        /// </para>
        /// </summary>
        string SIFKey { get; set; }
    }
}
