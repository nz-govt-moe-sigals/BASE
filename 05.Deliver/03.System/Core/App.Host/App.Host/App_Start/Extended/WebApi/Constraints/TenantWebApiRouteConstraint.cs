using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http.Routing;
using App.Core.Infrastructure.Services;

namespace App.Host.Extended.WebApi.Constraints
{
    public class TenantWebApiRouteConstraint : IHttpRouteConstraint
    {
        private readonly ITenantService _tenantService;

        public TenantWebApiRouteConstraint(ITenantService tenantService)
        {
            this._tenantService = tenantService;
        }
        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName,
            IDictionary<string, object> values,
            HttpRouteDirection routeDirection)
        {
            var tenantName = values[parameterName].ToString().ToLowerInvariant();
            var tenantService = this._tenantService;//  AppDependencyLocator.Current.GetInstance<ITenantService>();

            //(ITenantService)GlobalConfiguration.Configuration.DependencyResolver.GetService(
            //    typeof(ITenantService));

            var result = tenantService.IsValidTenantKey(tenantName);
#if DEBUG
            if (result)
            {
                //Makes it breakpointable.
                return true;
            }
#endif
            return result;
        }
    }
}