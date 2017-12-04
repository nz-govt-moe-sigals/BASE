namespace App.Core.Infrastructure.Services
{
    using System;

    public interface IUniversalDateTimeService : IHasAppCoreService
    {
        DateTimeOffset NowUtc();
    }
}