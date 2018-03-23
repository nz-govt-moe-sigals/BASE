namespace App.Core.Infrastructure.Services
{
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Services;

    /// <summary>
    /// Contract for an Infrastructure Service to 
    /// provide diagnostic tracing services.
    /// <para>
    /// In Azure these trace messages would probably be recored to 
    /// Blob storage.
    /// </para>
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Services.IHasAppCoreService" />
    public interface IDiagnosticsTracingService : IHasAppCoreService
    {
        void Trace(TraceLevel traceLevel, string message, params object[] arguments);
    }
}