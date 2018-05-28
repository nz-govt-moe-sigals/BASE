

namespace App.Core.Infrastructure.Services.Implementations
{
    using App.Core.Infrastructure.Services.Configuration.Implementations;
    using System.Net.Mail;

    /// <summary>
    ///     Implementation of the
    ///     <see cref="ISMTPService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Services.ISMTPService" />
    public class SMTPService : AppCoreServiceBase, ISMTPService
    {
        private readonly SMTPServiceConfiguration _smtpServiceConfiguration;

        private SmtpClient SmtpClient
        {
            get {
                return _smtpClient;
            }
        }
        SmtpClient _smtpClient;
        public SMTPService (SMTPServiceConfiguration smtpServiceConfiguration)
        {
            this._smtpServiceConfiguration = smtpServiceConfiguration;

            // configure the smtp server
            _smtpClient = new SmtpClient(_smtpServiceConfiguration.Configuration.BaseUri);

            _smtpClient.Credentials =
                new System.Net.NetworkCredential(
                _smtpServiceConfiguration.Configuration.Key,
                _smtpServiceConfiguration.Configuration.Secret);
        }

        public void Test(string toAddress, string subject, string body)
        {
            var msg = new MailMessage();

            msg.From = new MailAddress("info@YourWebSiteDomain.com");
            msg.To.Add(toAddress);
            msg.Subject = subject;
            msg.IsBodyHtml = true;
            msg.Body = body;

            // send the message
            _smtpClient.Send(msg);
        }
    }
}
