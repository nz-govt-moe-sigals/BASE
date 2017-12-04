namespace App.Core.Infrastructure.Services.Implementations
{
    using AutoMapper;

    public class ObjectMappingService : IObjectMappingService
    {
        public TTarget Map<TSource, TTarget>(TSource source) where TSource : class where TTarget : new()
        {
            var target = Mapper.Map<TSource, TTarget>(source);
            return target;
        }

        public TTarget Map<TSource, TTarget>(TSource source, TTarget target) where TSource : class where TTarget : class
        {
            target = Mapper.Map(source, target);
            return target;
        }
    }
}