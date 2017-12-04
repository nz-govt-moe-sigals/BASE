using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Core.Application.App_Start
{
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Configuration;
    using Microsoft.ApplicationInsights.Extensibility;
    using Owin;

    public class EnabledAnalytics
    {

        // Must be invoked before ServiceLocatorConfig is invoked.
        public static void Configure(IAppBuilder appBuilder)
        {

            var analyticsConfiguration =
                AppDependencyLocator.Current.GetInstance<IHostSettingsService>().GetObject<AnalyticsConfiguration>();

            TelemetryConfiguration.Active.DisableTelemetry = analyticsConfiguration.DisableTelemetry;

        }
    }


}