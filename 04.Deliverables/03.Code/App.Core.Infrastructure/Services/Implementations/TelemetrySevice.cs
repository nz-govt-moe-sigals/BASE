using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services.Implementations
{
    using Microsoft.ApplicationInsights;

    public class TelemetrySevice : ITelemetryService
    {
        public void TrackEvent(string message)
        {

            new TelemetryClient().TrackEvent(message);
        }
    }
}
