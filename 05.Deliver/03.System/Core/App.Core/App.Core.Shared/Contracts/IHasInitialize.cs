namespace App.Core.Shared.Contracts
{

    /// <summary>
    /// Contract for methods that have an Initialize() method.    
    /// </summary>
    public interface IHasInitialize
    {
        void Initialize();
    }


    /// <summary>
    /// Contract for methods that have an Initialize() method.    
    /// </summary>
    public interface IHasInitialize<in T>
    {
        void Initialize(T argument);
    }

}