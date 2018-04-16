namespace App.Core.Infrastructure.Services.Caches.Implementations
{
    using System.Collections.Generic;

    /// <summary>
    ///  Static cache object injected into KeyVault Service.
    /// </summary>
    public static class KeyVaultServiceConfigurationObjectCache
    {
        public static Dictionary<string, object> ObjectCache
        {
            get
            {
                return _objectCache;
            }
        }
        private static Dictionary<string, object> _objectCache = new Dictionary<string, object>();
    }
}