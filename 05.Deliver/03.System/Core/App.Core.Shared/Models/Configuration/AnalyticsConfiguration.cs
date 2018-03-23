using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Shared.Models.Configuration
{
    using App.Core.Shared.Attributes;

    /// <summary>
    /// An immutable host configuration object 
    /// describing the configuration of the 
    /// Application Insights service.
    /// </summary>
    public class ApplicationInsightsConfiguration
    {

        [Alias("App:Core:Integration:Azure:ApplicationInsights:InstrumentationKey")]
        public string Key { get; set; }

        [Alias("App:Core:Integration:Azure:ApplicationInsights:Disable")]
        public bool DisableTelemetry { get; set; }

    }
}
