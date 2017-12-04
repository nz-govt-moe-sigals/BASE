namespace App.Core.Infrastructure.Services
{
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Services;

    public interface ISessionOperationLogService : IHasAppCoreService
    {
        /// <summary>
        ///     Return the current Request Context's OperationLog record.
        ///     <para>
        ///         Creates a new one if this is the first request for the OperationLog.
        ///     </para>
        /// </summary>
        SessionOperation Current { get; }

    }
}