namespace App.Core.Infrastructure.Services
{
    using App.Core.Infrastructure.Services.Configuration;

    /// <summary>
    /// Contract for an Infrastructure Service to 
    /// provide Mime information.
    /// <para>
    /// Of use by MediaUploadServices as well as SMTP (attachment) services.
    /// </para>
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Services.IHasAppCoreService" />
    public interface IDictionaryBasedMimeTypeService : IHasAppCoreService
    {
        //IDictionaryBasedMimeTypeServiceConfiguration Configuration { get; }

        string GetMimeTypeFromFileExtension(string fileNameExtensionWithPrefixDot);
    }
}