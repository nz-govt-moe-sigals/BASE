using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services.Configuration.Implementations.AppHostNames
{
    public class HostsSection : ConfigurationSection
    {
        private const string HostsConfigProperty = "hostNames";
        private const string RoutesConfigProperty = "routeNames";

        [ConfigurationProperty(HostsConfigProperty)]
        public HostElementCollection Hosts
        {
            get { return ((HostElementCollection)(base[HostsConfigProperty])); }
            set { base[HostsConfigProperty] = value; }
        }

        [ConfigurationProperty(RoutesConfigProperty)]
        public RouteElementCollection Routes
        {
            get { return ((RouteElementCollection)(base[RoutesConfigProperty])); }
            set { base[RoutesConfigProperty] = value; }
        }
    }
}
