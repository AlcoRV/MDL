using MDL.Models;
using System.Net.Mail;
using System.Net;
using MDL.Interfaces;
using MDL.Options;
using Microsoft.Extensions.Options;

namespace MDL.Tools
{
    /// <summary>
    ///     Менеджер работы с сообщениями
    /// </summary>
    public sealed class MailManager: IMailManager
    {
        private readonly SmtpServerOptions _options;
        private readonly SmtpClient _smtp;

        /// <summary>
        ///     Конструктор почтового менеджера
        /// </summary>
        /// <param name="options">Настройки конфигурации</param>
        public MailManager(IOptions<SmtpServerOptions> options)
        {
            _options = options.Value;

            _smtp = new SmtpClient(_options.Client)
            {
                Credentials = new NetworkCredential(_options.Address, _options.Password),
                EnableSsl = true
            };
        }

        /// <summary>
        ///     Метод рассылки писем
        /// </summary>
        /// <param name="mail">Общее сообщение</param>
        public void SendMessages(Mail mail)
        {
            try
            {
                var recipients = mail.DeserializeRecipients();
                foreach (var recipient in recipients)
                {
                    SendMessage(mail.Subject, mail.Body, recipient);
                }

                mail.Result = CommonConstants.Mail.Result.OK;
            }
            catch(Exception e) {
                mail.FailedMessage = e.Message;
            }
        }

        private void SendMessage(string subject, string body, string recipient)
        {
            var from = new MailAddress(_options.Address, _options.Name);

            var to = new MailAddress(recipient);

            var message = new MailMessage(from, to)
            {
                Subject = subject,
                Body = body,

                IsBodyHtml = true
            };

            _smtp.Send(message);
        }
    }
}
