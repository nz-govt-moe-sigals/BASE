using Owin;

namespace App.Host.Middleware
{
    public static class BasicMiddlewareAppBuilderExtensions
    {
        public static void UseRequestTenantMiddleware(this IAppBuilder app)
        {
            // Set the Middleware/Module that will set the context's Tenancy.
            app.Use<RequestTenantMiddleware>();
        }
    }
}