﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Services.Configuration.Implementations;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace App.Core.Infrastructure.Services.Implementations
{
    /// <summary>
    /// <para>
    /// Unlike traditional caches which deal only with key-value pairs, Redis 
    /// is popular for its support of high performance data types, on which you 
    /// can perform atomic operations such as appending to a string, incrementing 
    /// the value in a hash, pushing to a list, computing set intersection, 
    /// union and difference, or getting the member with highest ranking in a sorted set.  
    /// Other features include support for transactions, pub/sub, Lua scripting, 
    /// keys with a limited time-to-live, and configuration settings 
    /// to make Redis behave more like a traditional cache.
    /// </para>
    /// </summary>
    public class AzureRedisCacheService : IAzureRedisCacheService
    {

        public AzureRedisCacheServiceConfiguration Configuration { get;private set; }
        Lazy<ConnectionMultiplexer> _lazyConnection;

        internal ConfigurationOptions ConfigurationOptions { get; private set; }

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


        public AzureRedisCacheService(AzureRedisCacheServiceConfiguration azureRedisCacheServiceConfiguration)
        {

            Configuration = azureRedisCacheServiceConfiguration;

            //var conn = ConnectionMultiplexer.Connect("localhost");
            this.ConfigurationOptions = ConfigurationOptions.Parse(azureRedisCacheServiceConfiguration.ConnectionString);

            ConfigurationOptions.ClientName = "...";
            ConfigurationOptions.AllowAdmin = false;
            ConfigurationOptions.AllowAdmin = false;
            ConfigurationOptions.Ssl = true;


            _lazyConnection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(this.ConfigurationOptions));
        }

        public void Set(string key, string value, TimeSpan? duration)
        {
            Database.StringSet(key, value, duration);
        }
        public string Get(string key)
        {
            return Database.StringGet(key);
        }

        public void Set<T>(string key, T value, TimeSpan? duration)
        {
            var tmp = JsonConvert.SerializeObject(value);
            Set(key, tmp, duration);
        }
        public T Get<T>(string key)
        {
            var tmp = Get(key);
            return JsonConvert.DeserializeObject<T>(tmp);
        }
        //public IEnumerable<T> Search(string key, string pattern)
        //{
        //    var r = Database.SortedSetScan(key,pattern);
        //    SortedSetEntry x;
        //    x.
        //}

        public string ExecuteCommand(string command)
        {
            // See: https://redis.io/commands for commands you can use.
            return Database.Execute(command).ToString();
        }

        public string[] ListClients()
        {
            string result = Database.Execute("CLIENT", "LIST").ToString().Replace(" id=", "\rid=");
            return result.Split('\n');
        }



        //public void SubscribeToEvents()
        //{
        //    var subscriber = _lazyConnection.Value.GetSubscriber();
        //    string notificationChannel = "__keyspace@" + dbId + "__:*";
            
        //    subscriber.Subscribe()

        //    https://github.com/rustd/RedisSamples/blob/master/HelloWorld/KeySpaceNotifications.cs
        //}
    }
}
