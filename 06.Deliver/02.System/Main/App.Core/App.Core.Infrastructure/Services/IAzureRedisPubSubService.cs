using System;

namespace App.Core.Infrastructure.Services
{
    public interface IAzureRedisPubSubService : IHasAppCoreService
    {
        // See: https://www.codeproject.com/Articles/846564/Azure-Redis-Cache

        void Subscribe(string key, Action<string, string> onReceive);
        void Publish(string key, string message);

    }
}
