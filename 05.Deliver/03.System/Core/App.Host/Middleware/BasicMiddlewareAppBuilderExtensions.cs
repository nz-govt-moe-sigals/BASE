using Owin;

namespace App.Host.Middleware
{
    public static class BasicMiddlewareAppBuilderExtensions
    {
        public static void UseRequestTenantMiddleware(this IAppBuilder app)
        {
            app.Use<RequestTenantMiddleware>();
        }
    }
}