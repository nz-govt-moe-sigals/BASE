﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Core.Application.App_Start
{
    using System.Configuration;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Configuration;
    using Microsoft.ApplicationInsights.Extensibility;
    using Owin;

    public class EnabledAnalytics
    {

        /// <summary>
        /// <para>
        /// Invoked from <see cref="StartupConfigure.Configure"/>
        /// </para>
        /// <para>
        /// Must be invoked before ServiceLocatorConfig is invoked.
        /// </para>
        /// </summary>
        /// <param name="appBuilder"></param>
        public static void Configure(IAppBuilder appBuilder)
        {

            var analyticsConfiguration =
                AppDependencyLocator.Current.GetInstance<IHostSettingsService>().GetObject<ApplicationInsightsConfiguration>();

            if (string.IsNullOrWhiteSpace(analyticsConfiguration.Key))
            {
                throw new ConfigurationErrorsException("Missing app setting 'App:Core:Integration:Azure:ApplicationInsights:InstrumentationKey' used for Application Insights.");
            }
            TelemetryConfiguration.Active.InstrumentationKey = analyticsConfiguration.Key;
            TelemetryConfiguration.Active.DisableTelemetry = analyticsConfiguration.DisableTelemetry;

            


    }
}


}