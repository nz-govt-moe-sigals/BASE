namespace App.Core.Shared.Models
{
    public interface IHasId<T>
    {
        T Id { get; set; }
    }
}