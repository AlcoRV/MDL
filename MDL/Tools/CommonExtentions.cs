using MDL.Models;
using MDL.ViewModels;
using Newtonsoft.Json;

namespace MDL.Tools
{
    /// <summary>
    ///     Общие методы расширения
    /// </summary>
    public static class CommonExtentions
    {
        /// <summary>
        ///     Метод расширения десериализации строки получателей
        /// </summary>
        /// <param name="mail">Сообщение</param>
        /// <returns>Массив получателей</returns>
        public static string[] DeserializeRecipients(this Mail mail)
        {
            var recipients = JsonConvert.DeserializeObject<string[]>(mail.Recipients);
            return recipients;
        }

        /// <summary>
        ///     Метод расширения преобразования модели почтового сообщения в модель представления
        /// </summary>
        /// <param name="mail">Сообщение</param>
        /// <returns></returns>
        public static MailViewModel ToMailViewModel(this Mail mail)
        {
            var viewModel = new MailViewModel()
            {
                Id = mail.Id,
                Subject = mail.Subject,
                Body = mail.Body,
                Recipients = mail.Recipients,
                Date = mail.Date,
                Result = mail.Result == CommonConstants.Mail.Result.OK ? CommonConstants.Mail.ResultOK : CommonConstants.Mail.ResultFailed,
                FailedMessage = mail.FailedMessage
            };
            return viewModel;
        }
    }
}
