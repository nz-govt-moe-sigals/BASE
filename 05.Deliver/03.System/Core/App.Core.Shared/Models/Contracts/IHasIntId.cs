namespace App.Core.Shared.Models
{
    /// <summary>
    /// Contract for Models (eg System models or DTO Message models) that
    /// use an Integer for the index.
    /// <para>
    /// In practice, integers Ids should be reserved for Immutable 
    /// Reference data. Anything other Model -- eg Mutable Reference data 
    /// or domain model - that can be edited from two different systems
    /// requires a Guid to ensure collision does not occur.
    /// (ie, prefer the use of <see cref="IHasGuidId"/> for most models in a system).
    /// </para>
    /// </summary>
    /// <seealso cref="int" />
    public interface IHasIntId : IHasId<int>
    {
    }
}