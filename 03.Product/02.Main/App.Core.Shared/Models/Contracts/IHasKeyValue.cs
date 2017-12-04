namespace App.Core.Shared.Models
{
    public interface IHasKeyValue<T> : IHasKey, IHasValue<T>
    {
    }
}