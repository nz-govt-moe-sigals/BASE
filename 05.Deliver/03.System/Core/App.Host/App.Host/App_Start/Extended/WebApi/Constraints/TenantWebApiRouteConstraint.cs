using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http.Routing;
using App.Core.Infrastructure.Services;

namespace App.Host.Extended.WebApi.Constraints
{
    /// <summary>
    /// A WebApi Route Constraint 
    /// to determin if the route of the given API url 
    /// contains the name of a Tenant.
    /// <para>Think of it as a Predicate Check.
    /// </para>
    /// </summary>
    public class TenantWebApiRouteConstraint : IHttpRouteConstraint
    {
        private readonly ITenantService _tenantService;

        /// <summary>
        /// COnstructor
        /// </summary>
        /// <param name="tenantService"></param>
        public TenantWebApiRouteConstraint(ITenantService tenantService)
        {
            this._tenantService = tenantService;
        }

        /// <summary>
        /// Given a route, determines if tenant is found in url.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="route"></param>
        /// <param name="parameterName"></param>
        /// <param name="values"></param>
        /// <param name="routeDirection"></param>
        /// <returns></returns>
        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName,
            IDictionary<string, object> values,
            HttpRouteDirection routeDirection)
        {
            var tenantName = values[parameterName].ToString().ToLowerInvariant();


            var result = _tenantService.IsValidTenantKey(tenantName);
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