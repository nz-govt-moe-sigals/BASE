namespace App.Core.Infrastructure.Services.Implementations
{
    using System.Web;

    /// <summary>
    ///     Implementation of the
    ///     <see cref="IOperationContextService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Services.IOperationContextService" />
    public class OperationContextService : AppCoreServiceBase, IOperationContextService
    {
        private readonly IConversionService _conversionService;

        public OperationContextService(IConversionService conversionService)
        {
            this._conversionService = conversionService;
        }

        public T Get<T>(string key, T defaultValue = default(T))
        {
            if (HttpContext.Current == null) { return defaultValue; }
            var result = this._conversionService.ConvertTo(HttpContext.Current.Items[key], defaultValue);
            return result;
        }

        public void Set<T>(string key, T value)
        {
            if (HttpContext.Current == null) { return; }
            HttpContext.Current.Items[key] = value;
        }
    }
}