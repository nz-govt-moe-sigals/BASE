using System;
using App.Core.Infrastructure.Services.Configuration.Implementations;
using StackExchange.Redis;

namespace App.Core.Infrastructure.Services.Implementations.AzureServices
{
    public class AzureRedisPubSubService : IAzureRedisPubSubService
    {
        private readonly IAzureRedisConnection _azureRedisConnection;

        
        public AzureRedisPubSubService(IAzureRedisConnection azureRedisConnection)
        {
            _azureRedisConnection = azureRedisConnection;
        }


        public void Subscribe(string key, Action <string, string> onReceive)
        {
            ISubscriber sub = _azureRedisConnection.ConnectionMultiplexer.GetSubscriber();

            sub.Subscribe("messages", (channel, message) =>
            {
                onReceive.Invoke(channel, message);
            });
        }

        public void Publish(string key, string message)
        {
            ISubscriber sub = _azureRedisConnection.ConnectionMultiplexer.GetSubscriber();
            sub.Publish(key, message);
        }
    }
}
