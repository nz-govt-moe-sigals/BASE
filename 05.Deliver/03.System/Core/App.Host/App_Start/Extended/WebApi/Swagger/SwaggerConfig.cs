using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using App.Core.Application.Initialization;
using Swashbuckle.Application;
using Swashbuckle.OData;
using WebActivatorEx;

//[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]
namespace App.Host.Extended.WebApi.Swagger
{
    /// <summary>
    /// A pipeline invoked class (class is decorated with <see cref="PreApplicationStartMethodAttribute"/> )to configure
    /// Swagger to generate documentation of registered REST APIs.
    /// </summary>
    public class SwaggerConfig
    {
        /// <summary>
        /// Registers this instance.
        /// <para>
        /// Invoked from <see cref="StartupExtended.Configure"/>.
        /// </para>
        /// </summary>
        public static void Register()
        {
            using (var elapsedTime = new ElapsedTime())
            {
                var path = "docs/api/{apiVersion}/";

                var httpconfiguration = HttpConfigurationLocator.Current;
              
                var apiExplorer = httpconfiguration.AddODataApiExplorer(
                    options =>
                    {
                        options.GroupNameFormat = "'v'VVV";

                        // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                        // can also be used to control the format of the API version in route templates
                        options.SubstituteApiVersionInUrl = true;
                        options.UseApiExplorerSettings = false;
                    });
             

                //So insted of using: System.Web.Http.GlobalConfiguration.Configuration
                // we use our personally created:
                httpconfiguration
                    .EnableSwagger(path, c =>
                    {

                        // By default, the service root url is inferred from the request used to access the docs.
                        // However, there may be situations (e.g. proxy and load-balanced environments) where this does not
                        // resolve correctly. You can workaround this by providing your own code to determine the root URL.
                        //
                        //c.RootUrl(req => GetRootUrlFromAppConfig());
                        // As per: https://github.com/domaindrivendev/Swashbuckle
                        // When you host Web API 2 on top of OWIN/SystemWeb, Swashbuckle cannot correctly resolve VirtualPathRoot by default.
                        // You must either explicitly set VirtualPathRoot in your HttpConfiguration at startup, or perform customization like this to fix automatic discovery:
                        c.RootUrl(req =>
                            req.RequestUri.GetLeftPart(UriPartial.Authority) +
                            req.GetRequestContext().VirtualPathRoot.TrimEnd('/'));


                        // If schemes are not explicitly provided in a Swagger 2.0 document, then the scheme used to access
                        // the docs is taken as the default. If your API supports multiple schemes and you want to be explicit
                        // about them, you can use the "Schemes" option as shown below.
                        //
                        c.Schemes(new[]
                        {
                            /*"http",*/ "https"
                        });

                        // Use "SingleApiVersion" to describe a single version API. Swagger 2.0 includes an "Info" object to
                        // hold additional metadata for an API. Version and title are required but you can also provide
                        // additional fields by chaining methods off SingleApiVersion.
                        //
                        //c.SingleApiVersion("v1", "App.Core.Application")
                        ;

                        // If you want the output Swagger docs to be indented properly, enable the "PrettyPrint" option.
                        //
                        c.PrettyPrint();

                        // build a swagger document and endpoint for each discovered API version
                        c.MultipleApiVersions(
                            (apiDescription, version) => apiDescription.GetGroupName() == version,
                            info =>
                            {
                                info.Version("v1", "Swashbuckle Dummy API V1");
                                info.Version("v2", "Swashbuckle Dummy API V2");
                                /*
                                foreach (var group in apiExplorer.ApiDescriptions)
                                {
                                    var description = "A sample application with Swagger, Swashbuckle, OData, and API versioning.";

                                    if (group.IsDeprecated)
                                    {
                                        description += " This API version has been deprecated.";
                                    }

                                    info.Version(group.Name, $"Sample API {group.ApiVersion}")
                                        .Contact(c => c.Name("Bill Mei").Email("bill.mei@somewhere.com"))
                                        .Description(description)
                                        .License(l => l.Name("MIT").Url("https://opensource.org/licenses/MIT"))
                                        .TermsOfService("Shareware");
                                }
                                */
                            });

                        // add a custom operation filter which documents the implicit API version parameter
                        c.OperationFilter<SwaggerDefaultValues>();


                        // Set this flag to omit descriptions for any actions decorated with the Obsolete attribute
                        c.IgnoreObsoleteActions();

                      

                        // Set this flag to omit schema property descriptions for any type properties decorated with the
                        // Obsolete attribute
                        c.IgnoreObsoleteProperties();

                     
                        // Wrap the default SwaggerGenerator with additional behavior (e.g. caching) or provide an
                        // alternative implementation for ISwaggerProvider with the CustomProvider option.
                        //
                        //c.CustomProvider((defaultProvider) => new CachingSwaggerProvider(defaultProvider));
                        //https://github.com/rbeauchamp/Swashbuckle.OData
                        /*
                        c.CustomProvider(defaultProvider => new ODataSwaggerProvider(defaultProvider, c, httpconfiguration).Configure(odataConfig =>
                        {
                            // Set this flag to include navigation properties in your entity swagger models
                            //
                            odataConfig.IncludeNavigationProperties();

                            // Enable Cache for swagger doc requests
                            odataConfig.EnableSwaggerRequestCaching();

                            //Set custom AssembliesResolver
                            //odataConfig.SetAssembliesResolver(new Utils.CustomAssembliesResolver());
                        }));
                        */
                        
                    })
                    .EnableSwaggerUi(c =>
                    {
                        // Use the "DocumentTitle" option to change the Document title.
                        // Very helpful when you have multiple Swagger pages open, to tell them apart.
                        //
                        c.DocumentTitle("My Swagger UI");
                        c.EnableDiscoveryUrlSelector();
                       // c.EnableDiscoveryUrlSelector();
                    });



                // Cannot record this fact as the event is too early (IoC has not yet been setup)
                //AppDependencyLocator.Current.GetInstance<IConfigurationStepService>().Register(
                //        ConfigurationStepType.General,
                //        ConfigurationStepStatus.White,
                //        "OpenAPI.",
                //        $"Swagger/OpenAPI initialized for '{path}'. Took {elapsedTime}");
            }


        }
    }
}
