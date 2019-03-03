

namespace App.Core.Infrastructure.Services.Implementations
{
    using App.Core.Infrastructure.Services.Configuration.Implementations;
    using System.Net.Mail;

    /// <summary>
    ///     Implementation of the
    ///     <see cref="ISmtpService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="ISmtpService" />
    public class SmtpService : AppCoreServiceBase, ISmtpService
    {
        private SMTPServiceConfiguration SmtpServiceConfiguration { get; }

        private SmtpClient SmtpClient { get; }

        public SmtpService (SMTPServiceConfiguration smtpServiceConfiguration)
        {
            SmtpServiceConfiguration = smtpServiceConfiguration;
            // configure the smtp server
            SmtpClient = new SmtpClient(smtpServiceConfiguration.Configuration.BaseUri);
            SmtpClient.Port = smtpServiceConfiguration.Configuration.Port ?? 587;
            SmtpClient.EnableSsl = true;
            SmtpClient.Credentials =
                new System.Net.NetworkCredential(
                    smtpServiceConfiguration.Configuration.Key,
                    smtpServiceConfiguration.Configuration.Secret);
        }

        public void SendMessage(string toAddress, string subject, string body)
        {
            var msg = new MailMessage();

            msg.From = new MailAddress(SmtpServiceConfiguration.Configuration.From);
            msg.To.Add(toAddress);
            msg.Subject = subject;
            msg.IsBodyHtml = true;
            msg.Body = body;

            // send the message
            SmtpClient.Send(msg);
        }
    }
}
