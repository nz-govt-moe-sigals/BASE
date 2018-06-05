using App.Core.Infrastructure.Initialization.DependencyResolution;

namespace App.Core.Application.Filters.WebApi
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Security.Claims;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using App.Core.Infrastructure.Services;

    // In WebAPI there are two base Filters to know about (with the dumbest/confusing names).
    // * AuthorizeFilterAttribute: used to validate if not based on current users (not sure when that would be the case)
    // * AuthorizeAttribute: used to validate the current user. 
    //   * Not that it enherits from AuthorizationFilterAttribute.
    //   * Note that it adds a Role property.
    //   * Note that it has an overrideable IsAuthorized method that by default validates
    //     the current Principals Roles.
    // * So you want to override this method, and replace it with logic to check
    //   the current OIDC Scope.
    public class WebApiAppAuthorizeAttribute : AuthorizeAttribute
    {

        private static readonly string[] _emptyArray = new string[0];

        private IPrincipalService PrincipalService
        {
            get { return AppDependencyLocator.Current.GetInstance<IPrincipalService>(); }
        }


        public new string Roles
        {
            get
            {
                return this._roles ?? string.Empty;
            }
            set
            {
                this._roles = value;
                this._rolesSplit = SplitString(value);
            }
        }
        private string _roles;
        private string[] _rolesSplit = new string[0];

        /// <summary>Indicates whether the specified control is authorized.</summary>
        /// <returns>true if the control is authorized; otherwise, false.</returns>
        /// <param name="actionContext">The context.</param>
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var request = actionContext.Request;

            // There's no controller for the metadata, so have to return true this way:
            if (IsAnODataMetadataRequests(request))
            {
                return true;
            }
            /*
            // The default behaviour that you are overrridding is as follows:
            if (actionContext == null)
                throw Error.ArgumentNull("actionContext");
            IPrincipal principal = actionContext.ControllerContext.RequestContext.Principal;
            return principal != null && principal.Identity != null && principal.Identity.IsAuthenticated &&
                   ((this._usersSplit.Length <= 0 ||
                     ((IEnumerable<string>) this._usersSplit).Contains<string>(principal.Identity.Name,
                         (IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase)) &&
                    (this._rolesSplit.Length <= 0 ||
                     ((IEnumerable<string>) this._rolesSplit).Any<string>(new Func<string, bool>(principal.IsInRole))));
            */

            if (string.IsNullOrEmpty(this.Roles))
            {
                //Whilst asking for Authorisation and not any associated roles is usually not good enough,
                //It can be warranted
                return true;
            }

            var principal = ClaimsPrincipal.Current;
            if (principal == null)
            {
                return false;
            }
            var scopeElement = App.Core.Infrastructure.Constants.IDA.ClaimTitles.ScopeElementId;
            var value = principal?.FindFirst(scopeElement)?.Value;
            if (value == null)
            {
                return false;
            }

            // Ensure a role in the attribute is found within the Principal's scopes:
            return this._rolesSplit.Any(role => value.Contains(role));
        }

        private static bool IsAnODataMetadataRequests(HttpRequestMessage request)
        {
            var absolutePath = request.RequestUri.AbsolutePath;
            if (absolutePath.EndsWith("/$metadata") || (absolutePath.EndsWith("/%24metadata")))
            {
                return true;
            }
            if (absolutePath.EndsWith("/$metadata/") || (absolutePath.EndsWith("/%24metadata/")))
            {
                return true;
            }
            return false;
        }


        static string[] SplitString(string original)
            {
                if (string.IsNullOrEmpty(original))
                {
                    return _emptyArray;
                }
                return ((IEnumerable<string>)original.Split(',')).Select(piece => new
                {
                    piece = piece,
                    trimmed = piece.Trim()
                }).Where(param0 => !string.IsNullOrEmpty(param0.trimmed)).Select(param0 => param0.trimmed).ToArray<string>();
            }

        }


    }