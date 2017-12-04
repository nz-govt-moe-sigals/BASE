namespace App.Core.Infrastructure.Services
{
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Services;

    public interface IDiagnosticsTracingService : IHasAppCoreService
    {
        void Trace(TraceLevel traceLevel, string message, params object[] arguments);
    }
}