using System;
using System.Reflection;
using System.Web.Http;
using System.Web.OData;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Models.Entities;
using Microsoft.Web.Http;
using Microsoft.Web.Http.Versioning.Conventions;

namespace App.Host.Extended.WebApi
{
    public class WebApiVersionConfig

    {
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;

        public WebApiVersionConfig(IDiagnosticsTracingService diagnosticsTracingService)
        {
            this._diagnosticsTracingService = diagnosticsTracingService;
        }

        public WebApiVersionConfig (HttpConfiguration configuration)
        {
            
            configuration.AddApiVersioning(options =>
            {
                var counter = 0;
                AppDomain.CurrentDomain.GetInstantiableTypesImplementing<ODataController>()
                .ForEach(
                        x =>
                        {                            
                            // We want to call the following generic convention:
                            // options.Conventions.Controller<x>().HasApiVersion(1, 0);
                            // but it's through reflection, of a generic method *and*
                            // extension method...a bit harder than usual reflection.

                            MethodInfo method = typeof(ApiVersionConventionBuilder).GetMethod("Controller");
                            MethodInfo genericMethod = method.MakeGenericMethod(x);
                            var controllerApiVersionConventionBuilder = genericMethod.Invoke(options.Conventions, null); // Invoke method to get back generic type
                            // Now invoke extension method
                            method = typeof(ControllerApiVersionConventionBuilder<>).GetMethod("HasApiVersion");
                            method.Invoke(controllerApiVersionConventionBuilder, new object[]{new ApiVersion(1, 0) });
                            var t = x.GetType();

                            this._diagnosticsTracingService.Trace(TraceLevel.Debug, $"{++counter}: Assigning REST Version to {t.Name}");

                        });

            } );
        }
    }
}