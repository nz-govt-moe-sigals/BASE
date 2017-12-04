namespace App.Core.Infrastructure.Services.Implementations
{
    using System.Web;

    public class OperationContextService : IOperationContextService
    {
        private readonly IConversionService _conversionService;

        public OperationContextService(IConversionService conversionService)
        {
            this._conversionService = conversionService;
        }

        public T Get<T>(string key, T defaultValue = default(T))
        {
            var result = this._conversionService.ConvertTo(HttpContext.Current.Items[key], defaultValue);
            return result;
        }

        public void Set<T>(string key, T value)
        {
            HttpContext.Current.Items[key] = value;
        }
    }
}