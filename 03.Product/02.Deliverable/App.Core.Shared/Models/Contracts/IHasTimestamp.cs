namespace App.Core.Shared.Models
{
    /// <summary>
    /// </summary>
    public interface IHasTimestamp
    {
        /// <summary>
        ///     Gets or sets the datastore concurrency check timestamp.
        ///     <para>
        ///         Note that this is filled in when persisted in the db --
        ///         so it's usable to determine whether Record is New or not.
        ///     </para>
        /// </summary>
        byte[] Timestamp { get; set; }
    }
}