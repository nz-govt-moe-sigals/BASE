using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Services.Configuration.Implementations;
using App.Core.Infrastructure.Services.Configuration.Implementations.AzureConfiguration;
using StackExchange.Redis;

namespace App.Core.Infrastructure.Services.Implementations.AzureServices
{
    public class AzureRedisConnection : IAzureRedisConnection
    {
        private readonly ConnectionMultiplexer _lazyConnection;
        private Guid _id;
        


        public AzureRedisConnection(AzureRedisCacheServiceConfiguration azureRedisCacheServiceConfiguration)
        {
            var configurationOptions = ConfigurationOptions.Parse(azureRedisCacheServiceConfiguration.ConnectionString);

            configurationOptions.ClientName = "...";
            configurationOptions.AllowAdmin = false;
            configurationOptions.Ssl = true;
            _id = Guid.NewGuid();
            Enabled = azureRedisCacheServiceConfiguration.Enabled;
            if (Enabled)
            {
                _lazyConnection = ConnectionMultiplexer.Connect(configurationOptions);
            }
            
        }

        public bool Enabled { get; }

        public ConnectionMultiplexer ConnectionMultiplexer => _lazyConnection;

        public IDatabase Database => ConnectionMultiplexer.GetDatabase();
    }
}
