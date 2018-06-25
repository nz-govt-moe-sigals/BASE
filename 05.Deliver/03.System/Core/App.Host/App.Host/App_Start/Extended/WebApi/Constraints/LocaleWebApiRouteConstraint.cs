using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http.Routing;
using App.Core.Infrastructure.Services;

namespace App.Host.Extended.WebApi.Constraints
{
    /// <summary>
    /// 
    /// <para>Think of it as a Predicate Check, that returns True/False.
    /// </para>
    /// </summary>
    public class LocaleWebApiRouteConstraint : IHttpRouteConstraint
    {
        private readonly ILocalisationService _localisationService;

        public LocaleWebApiRouteConstraint(ILocalisationService localisationService)
        {
            this._localisationService = localisationService;
        }

        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName,
            IDictionary<string, object> values,
            HttpRouteDirection routeDirection)
        {
            var locale = values[parameterName].ToString();

            //ILocalisationService localisationService =
            //    (ILocalisationService)GlobalConfiguration.Configuration.DependencyResolver.GetService(
            //        typeof(ILocalisationService));

            var result = this._localisationService.IsValidCultureInfoName(locale);
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