namespace App.Core.Infrastructure.Services
{
    using System.Collections.Generic;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Services;

    /// <summary>
    ///  Contract for an Infrastructure Service to
    /// record the current <see cref="SessionOperation"/>
    /// log that will be Committed at the end of the 
    /// Request (delayed so that it can record the Response Code).
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Services.IHasAppCoreService" />
    public interface ISessionOperationLogService : IHasAppCoreService
    {
        /// <summary>
        ///     Return the current Request Context's OperationLog record.
        ///     <para>
        ///         Creates a new one if this is the first request for the OperationLog.
        ///     </para>
        /// </summary>
        SessionOperation Current
        {
            get;
        }
        Dictionary<string,object> CurrentDetails { get; }

        object GetDetail(string key);
        void SetDetail(string key,object value);

        void IncrementDetail(string key);

    }
}