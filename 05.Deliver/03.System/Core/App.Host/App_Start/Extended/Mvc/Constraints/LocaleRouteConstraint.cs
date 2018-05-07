using System.Web;
using System.Web.Routing;
using App.Core.Infrastructure.Services;

namespace App.Host.Extended.Mvc.Constraints
{
    public class LocaleRouteConstraint : IRouteConstraint
    {
        private readonly ILocalisationService _localisationService;

        public LocaleRouteConstraint(ILocalisationService localisationService)
        {
            this._localisationService = localisationService;
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values,
            RouteDirection routeDirection)
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

            //string url = httpContext.Request.RawUrl;


            //if (localisationService.ThreadCultureSet)
            //{
            //    return true;
            //}


            //if (locale == "--")
            //{
            //    // Not defined in route, so fall back to 
            //    // Principal Claimed Preferred language,
            //    // TODO:
            //    IPrincipalService principalService =
            //        (IPrincipalService) GlobalConfiguration.Configuration.DependencyResolver.GetService(
            //            typeof(IPrincipalService));

            //    // See if it's defined in the user's Claims, and if not defined, the browser's defined preference:
            //    // Note that the browser stores the locale codes as a scored array:
            //    // [0]: "en-US"
            //    // [1]: "en;q=0.8"
            //    // [2]: "da;q=0.6"
            //    // [3]: "sv;q=0.4"
            //    locale = principalService.ClaimPreferredCultureCode ??
            //           httpContext.Request.UserLanguages?.FirstOrDefault()?.Split(';')[0] ?? "en";
            //}


            //localisationService.SetThreadCulture(locale);

            //return true;
        }
    }
}