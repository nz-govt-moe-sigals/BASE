using App.Core.Infrastructure.Services.Configuration.Implementations;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services.Implementations
{
    public class AzureRedisPubSubService : IAzureRedisPubSubService
    {

        Lazy<ConnectionMultiplexer> _lazyConnection;

        private ConnectionMultiplexer ConnectionMultiplexer
        {
            get
            {
                return _lazyConnection.Value;
            }
        }
        private IDatabase Database
        {
            get
            {
                return ConnectionMultiplexer.GetDatabase();
            }
        }
        public AzureRedisPubSubService(AzureRedisCacheServiceConfiguration azureRedisCacheServiceConfiguration)
        {


            //var conn = ConnectionMultiplexer.Connect("localhost");
            var configurationOptions = ConfigurationOptions.Parse(azureRedisCacheServiceConfiguration.ConnectionString);

            configurationOptions.ClientName = "...";
            configurationOptions.AllowAdmin = false;
            configurationOptions.Ssl = true;

            _lazyConnection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(configurationOptions));
        }


        public void Subscribe(string key, Action <string, string> onReceive)
        {
            ISubscriber sub = ConnectionMultiplexer.GetSubscriber();

            sub.Subscribe("messages", (channel, message) =>
            {
                onReceive.Invoke(channel, message);
            });
        }
        public void Publish(string key, string message)
        {
            ISubscriber sub = ConnectionMultiplexer.GetSubscriber();
            sub.Publish(key, message);
        }
    }
}
