using MDL.Models;

namespace MDL.Interfaces
{
    /// <summary>
    ///     Интерфейс менеджера рассылки писем
    /// </summary>
    public interface IMailManager
    {
        /// <summary>
        ///     Метод рассылки
        /// </summary>
        /// <param name="mail">Сообщение</param>
        void SendMessages(Mail mail);
    }
}
