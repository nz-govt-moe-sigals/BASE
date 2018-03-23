namespace App.Core.Infrastructure.IDA.Models
{
    using App.Core.Infrastructure.IDA.Models.Enums;
    using App.Core.Shared.Attributes;

    public class AuthorisationConfiguration
    {
        [Alias("AuthorisationDemoType")]
        public AuthorisationDemoType AuthorisationDemoType { get; set; }
    }
}