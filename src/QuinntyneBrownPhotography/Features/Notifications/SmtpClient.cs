using System.Net;

namespace QuinntyneBrownPhotography.Features.Notifications
{
    public class SmtpClient : IMessageSender
    {
        public SmtpClient(ISmtpConfiguration configuration)
        {
            _configuration = configuration;
            _smtpClient = new System.Net.Mail.SmtpClient(this._configuration.Host, this._configuration.Port)
            {
                Credentials = new NetworkCredential(this._configuration.Username, this._configuration.Password),
                EnableSsl = true
            };
        }

        public void Send(System.Net.Mail.MailMessage mailMessage) => _smtpClient.Send(mailMessage);

        System.Net.Mail.SmtpClient _smtpClient { get; set; }
        ISmtpConfiguration _configuration { get; set; }
    }
}
