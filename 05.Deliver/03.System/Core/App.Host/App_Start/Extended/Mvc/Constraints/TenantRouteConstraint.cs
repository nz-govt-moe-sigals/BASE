using System.Web;
using System.Web.Routing;
using App.Core.Infrastructure.Initialization.DependencyResolution;
using App.Core.Infrastructure.Services;

namespace App.Host.Extended.Mvc.Constraints
{

    public class TenantRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            var tenantName = values[parameterName].ToString().ToLowerInvariant();
            var tenantService = AppDependencyLocator.Current.GetInstance<ITenantService>();
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