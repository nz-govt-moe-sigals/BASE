

namespace App.Core.Infrastructure.Services.Implementations
{
    using App.Core.Infrastructure.Services.Configuration.Implementations;

    public class SMTPService : ISMTPService
    {
        private readonly SMTPServiceConfiguration _smtpServiceConfiguration;

        public SMTPService (SMTPServiceConfiguration smtpServiceConfiguration)
        {
            this._smtpServiceConfiguration = smtpServiceConfiguration;
        }
    }
}
