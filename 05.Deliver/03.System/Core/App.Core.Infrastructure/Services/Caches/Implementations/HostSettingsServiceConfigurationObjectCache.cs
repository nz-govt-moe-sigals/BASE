namespace App.Core.Infrastructure.Services.Caches.Implementations
{
    using System.Collections.Generic;

    /// <summary>
    /// Static cache that is injected into 
    /// IHostSettingsService.
    /// </summary>
    public static class HostSettingsServiceConfigurationObjectCache
    {
        public static Dictionary<string, object> ObjectCache { get { return _objectCache; } }
        private static Dictionary<string, object> _objectCache = new Dictionary<string, object>();
    }
}