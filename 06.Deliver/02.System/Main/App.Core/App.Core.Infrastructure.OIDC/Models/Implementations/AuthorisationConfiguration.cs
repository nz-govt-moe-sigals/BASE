using App.Core.Infrastructure.IDA.Constants.HostSettingsKeys;
using App.Core.Infrastructure.IDA.Models.Enums;
using App.Core.Shared.Attributes;

namespace App.Core.Infrastructure.IDA.Models.Implementations
{
    public class AuthorisationConfiguration
    {
        [Alias(AuthorisationSetup.AuthorisationType)]
        public AuthorisationType AuthorisationType { get; set; }
    }
}