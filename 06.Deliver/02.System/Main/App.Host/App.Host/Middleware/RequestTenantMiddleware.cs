using System.Threading.Tasks;
using App.Core.Infrastructure.Initialization.DependencyResolution;
using App.Core.Infrastructure.Services;
using Microsoft.Owin;

namespace App.Host.Middleware
{
    public class RequestTenantMiddleware : OwinMiddleware
    {
        public RequestTenantMiddleware(OwinMiddleware next) : base(next)
        {
        }

        public override async Task Invoke(IOwinContext context)
        {
            // TODO: This Middleware is hit *before* the RouteHandler get's invoked.
            // Unfortunately, I've been unable to  update the Route and clean it up
            // before it gets there.

            var tenantService = AppDependencyLocator.Current.GetInstance<ITenantService>();

            var hostName = context.Request.Host;

            var tenant = tenantService.SetTenantFromUrl(context.Request.Path.Value, hostName.Value);


            //context.Request.Path = new PathString(string.Join("/", parts));
            //Uri uri = context.Request.Uri;

            // Url routing will happen here...
            await this.Next.Invoke(context);
            // Before it gets to here.
        }
    }
}