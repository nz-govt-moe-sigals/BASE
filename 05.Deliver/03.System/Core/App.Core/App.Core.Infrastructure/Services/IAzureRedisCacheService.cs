using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services
{
    public interface IAzureRedisCacheService : IHasAppCoreService
    {

        void Set(string key, string message, TimeSpan? duration);
        string Get(string key);

        void Set<T>(string key, T value, TimeSpan? duration);
        T Get<T>(string key);

    }
}
