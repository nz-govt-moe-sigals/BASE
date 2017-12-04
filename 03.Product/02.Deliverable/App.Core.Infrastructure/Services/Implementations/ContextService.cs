namespace App.Core.Infrastructure.Services.Implementations
{
    using System.Web;

    public class ContextService : IContextService
    {
    public void Set(string key, object value)
        {
            HttpContext.Current.Items[key] = value;
        }

        public object Get(string key)
        {
            return HttpContext.Current.Items[key];
        }
    }
}