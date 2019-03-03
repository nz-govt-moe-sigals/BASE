using System.Web;
using System.Web.Routing;
using App.Core.Infrastructure.Initialization.DependencyResolution;
using App.Core.Infrastructure.Services;

namespace App.Host.Extended.Mvc.Constraints
{
    public interface ITenantRouteConstraint : IRouteConstraint
    {

    }


    public class TenantRouteConstraint : ITenantRouteConstraint
    {
        private readonly ITenantService _tenantService;
        private bool? _match; // can cache because it should always be the first!
        public TenantRouteConstraint(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }


        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            if (_match.HasValue) { return _match.Value; }
            var tenantName = values[parameterName].ToString().ToLowerInvariant();
            //(ITenantService)GlobalConfiguration.Configuration.DependencyResolver.GetService(
            //    typeof(ITenantService));

            var result = _tenantService.IsValidTenantKey(tenantName);
            _match = result;
            return result;
        }
    }
}