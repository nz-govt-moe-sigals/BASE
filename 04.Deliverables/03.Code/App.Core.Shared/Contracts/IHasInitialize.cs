namespace App.Core.Shared.Contracts
{
    // Contract for methods that have an Initialize() method.
    public interface IHasInitialize
    {
        void Initialize();
    }


    public interface IHasInitialize<in T>
    {
        void Initialize(T argument);
    }

}