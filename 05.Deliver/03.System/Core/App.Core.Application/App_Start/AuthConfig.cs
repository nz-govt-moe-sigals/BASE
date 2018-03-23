namespace App.Core.Application
{
    using System.Collections.Generic;
    using App.Core.Infrastructure.IDA.Models;
    using App.Core.Infrastructure.IDA.Models.Enums;
    using App.Core.Infrastructure.IDA.Owin;
    using App.Core.Infrastructure.IDA.Services;
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.Authentication;
    using App.Core.Infrastructure.Services;
    using Owin;

    /// <summary>
    /// An <see cref="StartupExtended"/> invoked class to configure
    /// the specified application builder.
    /// </summary>
    public class AuthConfig
    {
        /// <summary>
        /// Configures the specified application builder.
        /// <para>
        /// Invoked from <see cref="StartupExtended.Configure"/>
        /// </para>
        /// </summary>
        /// <param name="appBuilder">The application builder.</param>
        public static void Configure(IAppBuilder appBuilder)
        {
            // No:
            //_diagnosticsTracingService = StructuremapMvc.StructureMapDependencyScope.Container.GetInstance<IDiagnosticsTracingService>();
            // _hostSettingsService =StructuremapMvc.StructureMapDependencyScope.Container.GetInstance<IHostSettingsService>();
            // Better (no direct reference to 3rd party vendor, allowing you how-swap DI service providers without change to code):
            var diagnosticsTracingService = AppDependencyLocator.Current.GetInstance<IDiagnosticsTracingService>();
            var hostSettingsService = AppDependencyLocator.Current.GetInstance<IHostSettingsService>();

            var scopes = ScanForAllModulesRequiredScopeDefinitions();


            var authorisationConfiguration = hostSettingsService.GetObject<AuthorisationConfiguration>();
            var demoType = authorisationConfiguration.AuthorisationDemoType;


            IOIDCNotificationHandlerService oidcNotificationHandlerService =
                AppDependencyLocator.Current.GetInstance<IOIDCNotificationHandlerService>();


            switch (demoType)
            {
                case AuthorisationDemoType.AADUsingOIDCAndCookies:
                    AppDependencyLocator.Current.GetInstance<AADV2ForOIDCCookiesConfiguration>()
                        .Configure(appBuilder, hostSettingsService, oidcNotificationHandlerService);
                    break;
                case AuthorisationDemoType.B2CUsingOIDCAndCookies:
                    AppDependencyLocator.Current.GetInstance<B2COAuthCookieBasedAuthenticationConfig>()
                        .Configure(appBuilder, scopes);
                    break;
                case AuthorisationDemoType.B2CUsingOIDCAndBearerTokens:
                    AppDependencyLocator.Current.GetInstance<B2COAuthBearerTokenAuthenticationConfiguration>()
                        .Configure(appBuilder);
                    break;
                case AuthorisationDemoType.B2CUsingOIDCAndCookiesAndBearerTokens:
                    AppDependencyLocator.Current.GetInstance<B2COAuthBearerTokenAuthenticationConfiguration>()
                        .Configure(appBuilder);
                    AppDependencyLocator.Current.GetInstance<B2COAuthCookieBasedAuthenticationConfig>()
                        .Configure(appBuilder, scopes);
                    break;
            }
        }

        private static string[] ScanForAllModulesRequiredScopeDefinitions()
        {
            var scopes = new string[] { };
            var t = new List<string>();
            AppDependencyLocator.Current.GetAllInstances<IHasOidcScopeInitializer>()
                .ForEach(x => t.AddRange(x.FullyQualifiedScopeDefinitions));
            scopes = t.ToArray();
            return scopes;
        }

        
    }
}