namespace App.Core
{
    using App.Core.Application.Middleware;
    using Owin;

    public static class BasicMiddlewareAppBuilderExtensions
    {
        public static void UseRequestTenantMiddleware(this IAppBuilder app)
        {
            app.Use<RequestTenantMiddleware>();
        }
    }
}