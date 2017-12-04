namespace App.Core.Infrastructure.Services.Implementations
{
    using System;

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