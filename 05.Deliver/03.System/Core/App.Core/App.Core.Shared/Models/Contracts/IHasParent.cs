namespace App.Core.Shared.Models
{
    public interface IHasParent<T> : IHasParentFK
    {
        T Parent { get; set; }
    }


}