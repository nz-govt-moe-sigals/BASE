namespace App.Core.Shared.Models
{
    /// <summary>
    ///     Contract for models that have a Name (not automatically unique).
    ///     See IHasKey.
    /// </summary>
    public interface IHasName
    {
        string Name { get; set; }
    }
}