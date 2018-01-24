namespace App.Core.Infrastructure.Services.Implementations
{
    using System;

    /// <summary>
    /// Implementation of a
    /// Contract for an infrastructure service to
    /// return UTC based DateTimeOffset (not just UTC DateTime, 
    /// and certainly not Local DateTime!)
    /// to all services that need to coordinate datetime in a
    /// geo-capable manner (which you certainly need to do when
    /// you are hosting some infrastructure in one timezone, 
    /// and other pieces in another).
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Services.IUniversalDateTimeService" />
    public class UniversalDateTimeService : IUniversalDateTimeService
    {
        /// <summary>
        /// Return the DateTime, in UTC.
        /// </summary>
        /// <returns></returns>
        public DateTimeOffset NowUtc()
        {
            return DateTimeOffset.UtcNow;
        }
    }
}