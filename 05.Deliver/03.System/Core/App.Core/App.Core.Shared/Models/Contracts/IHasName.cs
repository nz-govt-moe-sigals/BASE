namespace App.Core.Shared.Models
{
    /// <summary>
    ///     Contract for models that have a Name (not automatically unique).
    ///     <para>
    ///     NOTE: prefer the use of <see cref="IHasKey"/> if the value is unique.
    /// </para>
    /// <para>
    /// Consider also <see cref="IHasTitle"/> if it's just a displayable name. </para>
    /// </summary>
    public interface IHasName
    {

        string Name { get; set; }
    }
}