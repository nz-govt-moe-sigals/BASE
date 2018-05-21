namespace App.Module3.Shared.Models
{
    /// <summary>
    /// Contract for system entity objects
    /// that record the key from the source system.
    /// </summary>
    public interface IHasSourceSystemKey
    {
        /// <summary>
        /// Gets or sets the name of systme that provided
        /// the <see cref="SourceSystemKey"/> (eg: FIRST).
        /// </summary>
        string SourceSystemName { get; set; }

        /// <summary>
        /// Gets or sets the MOE source (eg: FIRST) defined key.
        /// <para>
        /// The type is string as not all source codes
        /// are integers (eg: LocalOffice is a string).
        /// </para>
        /// </summary>
        string SourceSystemKey { get; set; }
    }
}