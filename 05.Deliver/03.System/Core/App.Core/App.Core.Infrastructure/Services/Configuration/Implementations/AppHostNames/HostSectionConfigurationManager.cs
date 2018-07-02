using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services.Configuration.Implementations.AppHostNames
{
    public class HostSectionConfigurationManager
    {
        public HostSectionConfigurationManager()
        {
            InitHostNames();
            InitRouteValues();
        }

        private void InitRouteValues()
        {
            var hostNames = new HashSet<RouteElement>();
            if (ConfigurationManager.GetSection("hostsSection") is HostsSection section)
            {
                var routes = (section.Routes);
                for (int i = 0; i < routes.Count; i++)
                {
                    hostNames.Add(routes[i]);
                }
            }

            if (hostNames.Count == 0)
            {
                hostNames = new HashSet<RouteElement>()
                {
                    new RouteElement("odata"),
                    new RouteElement("api")
                };
            }
                
            RoutesToIgnore = hostNames;
        }

        private void InitHostNames()
        {
            var hostNames = new HashSet<HostElement>();
            if (ConfigurationManager.GetSection("hostsSection") is HostsSection section)
            {
                var hosts = (section.Hosts);
                for (int i = 0; i < hosts.Count; i++)
                {
                    hostNames.Add(hosts[i]);
                }
            }

            HostNames = hostNames;
        }

        public IEnumerable<RouteElement> RoutesToIgnore { get; private set; }


        public IEnumerable<HostElement> HostNames { get; private set; }
    }
}
