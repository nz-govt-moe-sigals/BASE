namespace App.Core.Application.Filters.WebMvc
{
    using System;
    using System.Web.Mvc;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class MyRequireHttpsWebMvcFilterAttribute : RequireHttpsAttribute
    {
        /// <summary>
        ///     Determines whether a request is secured (HTTPS) and, if it is not, calls the
        ///     <see cref="M:System.Web.Mvc.RequireHttpsAttribute.HandleNonHttpsRequest(System.Web.Mvc.AuthorizationContext)" />
        ///     method.
        /// </summary>
        /// <param name="filterContext">
        ///     An object that encapsulates information that is required in order to use the
        ///     <see cref="T:System.Web.Mvc.RequireHttpsAttribute" /> attribute.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="filterContext" /> parameter is null.</exception>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
        }
    }
}