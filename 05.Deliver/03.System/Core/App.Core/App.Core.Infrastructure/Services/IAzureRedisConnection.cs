using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace App.Core.Infrastructure.Services
{
    public interface IAzureRedisConnection
    {
        ConnectionMultiplexer ConnectionMultiplexer { get; }

        IDatabase Database { get; }

        bool Enabled { get; }
    }
}
