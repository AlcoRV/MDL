using MDL.Models;
using System.Net.Mail;
using System.Net;

namespace MDL.Tools
{
    public class MailManager
    {
        public void SendMessages(Mail mail)
        {
            try
            {
                var recipients = mail.DeserializeRecipients();
                foreach (var recipient in recipients)
                {
                    SendMessage(mail.Subject, mail.Body, recipient);
                }

                mail.Result = "OK";
            }
            catch(Exception e) {
                mail.Result = "Failed";
                mail.FailedMessage = e.Message;
            }
        }

        private static void SendMessage(string subject, string body, string recipient)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            var serverAddress = configuration["SMTPServer:Address"];
            var serverName = configuration["SMTPServer:Name"];
            if (serverAddress is null) { throw new NullReferenceException("Not correct server's address!"); }

            var from = new MailAddress(serverAddress, serverName);

            var to = new MailAddress(recipient);

            var message = new MailMessage(from, to)
            {
                Subject = subject,
                Body = body,

                IsBodyHtml = true
            };

            var smtp = new SmtpClient(configuration["SMTPServer:Client"])
            {
                Credentials = new NetworkCredential(serverAddress, configuration["SMTPServer:Password"]),
                EnableSsl = true
            };
            smtp.Send(message);
        }
    }
}
