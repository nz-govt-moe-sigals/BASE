namespace App.Core.Infrastructure.Services.Implementations
{
    using System;

    /// <summary>
    ///     Implementation of the
    ///     <see cref="IConversionService" />
    ///     Infrastructure Service Contract
    /// 
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Services.IConversionService" />
    public class ConversionService : IConversionService
    {
        public T ConvertTo<T>(object source, T defaultValue = default(T))
        {
            return source.ConvertTo(defaultValue);
        }


        public object GetDefaultValue(Type t)
        {
            return t.GetDefaultValue();
        }
    }
}