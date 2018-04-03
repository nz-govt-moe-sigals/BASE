namespace App.Core.Application.Extended
{
    using System.Web.Http;
    using System.Web.Http.Cors;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Messages;

    /// <summary>
    /// An <see cref="StartupExtended"/> invoked class to configure 
    /// Cors for WebApi (which is required when Mashing from UI).
    /// </summary>
    public class WebApiCorsConfig
    {
        /// <summary>
        /// An <see cref="StartupExtended"/> invoked class to configure 
        /// the specified HTTP configuration.
        /// <para>
        /// Invoked from <see cref="StartupExtended.Configure"/>.
        /// </para>
        /// </summary>
        /// <param name="httpConfiguration">The HTTP configuration.</param>
        public static void Configure(HttpConfiguration httpConfiguration)
        {
            using (var elapsedTime = new ElapsedTime())
            {
                // SETUP STEP: Enable CORS via Microsoft.AspNet.WebApi.Cors package.
                // As per https://docs.microsoft.com/en-us/aspnet/web-api/overview/security/enabling-cross-origin-requests-in-web-api
                httpConfiguration.EnableCors(new EnableCorsAttribute("*", "*", "*", "*"));
                // Note that the above can be locked down by decorating WebAPI and OData Controller
                // classes and Actions with Attributes similar to:
                // [EnableCors(origins: "http://localhost:5901,http://localhost:8768", headers: "*", methods: "post,get")]

                AppDependencyLocator.Current.GetInstance<IConfigurationStepService>()
                    .Register(
                        ConfigurationStepType.Security,
                        ConfigurationStepStatus.White,
                        "CORS Enabled",
                        $"'*' For Origins, Headers, Actions, ExposedHeaders. Took {elapsedTime.ElapsedText}");
            }

        }
    }
}