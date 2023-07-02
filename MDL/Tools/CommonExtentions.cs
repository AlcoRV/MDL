using MDL.Models;
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
    }
}
