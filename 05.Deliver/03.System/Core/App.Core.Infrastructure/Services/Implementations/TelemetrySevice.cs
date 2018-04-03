using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services.Implementations
{
    using Microsoft.ApplicationInsights;

    /// <summary>
    ///     Implementation of the
    ///     <see cref="ITelemetryService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Services.ITelemetryService" />
    public class TelemetrySevice : AppCoreServiceBase, ITelemetryService
    {
        public void TrackEvent(string message)
        {

            new TelemetryClient().TrackEvent(message);
        }
    }
}
