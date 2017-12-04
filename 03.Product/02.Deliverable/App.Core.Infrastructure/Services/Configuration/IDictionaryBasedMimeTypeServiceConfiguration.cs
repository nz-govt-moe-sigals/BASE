namespace App.Core.Infrastructure.Services.Configuration
{
    using System.Collections.Generic;

    public interface IDictionaryBasedMimeTypeServiceConfiguration
    {
        Dictionary<string, string> Cache { get; }
    }
}