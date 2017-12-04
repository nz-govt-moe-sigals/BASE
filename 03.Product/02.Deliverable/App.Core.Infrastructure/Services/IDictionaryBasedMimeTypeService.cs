namespace App.Core.Infrastructure.Services
{
    using App.Core.Infrastructure.Services.Configuration;

    public interface IDictionaryBasedMimeTypeService : IHasAppCoreService
    {
        IDictionaryBasedMimeTypeServiceConfiguration Configuration { get; }

        string GetMimeTypeFromFileExtension(string fileNameExtensionWithPrefixDot);
    }
}