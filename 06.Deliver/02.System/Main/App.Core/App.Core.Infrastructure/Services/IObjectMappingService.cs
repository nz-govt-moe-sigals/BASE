namespace App.Core.Infrastructure.Services
{
    using App.Core.Shared.Services;

    public interface IObjectMappingService : IHasAppCoreService
    {
        TTarget Map<TSource, TTarget>(TSource source) where TSource : class where TTarget : new();
        TTarget Map<TSource, TTarget>(TSource source, TTarget target) where TSource : class where TTarget : class;
    }
}