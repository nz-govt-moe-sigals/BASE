namespace App.Core.Infrastructure.Services
{
    using App.Core.Shared.Services;

    /// <summary>
    ///     Contract for a service that manages variables
    ///     within the current Operation's context. In a web app, that's
    ///     equivalent to the HttpContext.
    /// </summary>
    public interface IOperationContextService : IHasAppCoreService
    {
        T Get<T>(string key, T defaultValue = default(T));
        void Set<T>(string key, T value);
    }
}