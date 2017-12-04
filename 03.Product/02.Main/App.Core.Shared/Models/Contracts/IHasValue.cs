namespace App.Core.Shared.Models
{
    public interface IHasValue<T>
    {
        T Value { get; set; }
    }
}