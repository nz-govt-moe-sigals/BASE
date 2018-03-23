namespace App.Core.Infrastructure.Services
{
    using System.Collections;
    using App.Core.Shared.Services;

    public interface ISecureAPIMessageAttributeService : IHasAppCoreService
    {
        void Process(IEnumerable models);
        void Process(object model);
    }
}