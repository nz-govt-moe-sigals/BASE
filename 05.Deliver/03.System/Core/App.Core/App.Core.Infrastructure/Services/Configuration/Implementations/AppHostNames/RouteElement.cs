using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services.Configuration.Implementations.AppHostNames
{
    public class RouteElement : ConfigurationElement
    {
        public RouteElement()
        {

        }

        public RouteElement(string name)
        {
            base["name"] = name;
        }


        [ConfigurationProperty("name", IsRequired = false)]
        public string Name
        {
            get { return (string)base["name"]; }
        }
    }
}
