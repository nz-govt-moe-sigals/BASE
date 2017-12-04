namespace App.Core.Infrastructure.Services.Implementations
{
    using System;

    public class UniversalDateTimeService : IUniversalDateTimeService
    {
        public DateTimeOffset NowUtc()
        {
            return DateTimeOffset.UtcNow;
        }
    }
}