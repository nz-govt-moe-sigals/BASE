

namespace App.Core.Infrastructure.Services.Implementations
{
    using App.Core.Infrastructure.Services.Configuration.Implementations;

    /// <summary>
    ///     Implementation of the
    ///     <see cref="ISMTPService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Services.ISMTPService" />
    public class SMTPService : ISMTPService
    {
        private readonly SMTPServiceConfiguration _smtpServiceConfiguration;

        public SMTPService (SMTPServiceConfiguration smtpServiceConfiguration)
        {
            this._smtpServiceConfiguration = smtpServiceConfiguration;
        }
    }
}
