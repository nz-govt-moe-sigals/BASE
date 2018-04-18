namespace App.Module3.Shared.Models
{
    public interface IHasFIRSTKey
    {
        /// <summary>
        /// Gets or sets the FIRST System defined key.
        /// <para>
        /// Note that it is a string (and not just an int)
        /// because of theCode used for LocalOffice).
        /// </para>
        /// </summary>
        /// <value>
        /// The first key.
        /// </value>
        string FIRSTKey { get; set; }
    }
}