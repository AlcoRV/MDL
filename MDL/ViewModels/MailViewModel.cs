using System.ComponentModel.DataAnnotations;

namespace MDL.ViewModels
{
    /// <summary>
    ///     Модель представления почтового сообщения
    /// </summary>
    public sealed class MailViewModel
    {
        /// <summary>
        ///     Id сообщения
        /// </summary>
        public Guid? Id { get; set; }
        /// <summary>
        ///     Дата отправки
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        ///     Тема сообщения
        /// </summary>
        public string? Subject { get; set; }

        /// <summary>
        ///     Содержание сообщения
        /// </summary>
        public string? Body { get; set; }

        /// <summary>
        ///     Список получателей в формате JSON
        /// </summary>
        public string? Recipients { get; set; }

        /// <summary>
        ///     Результат отправки сообщений
        /// </summary>
        public string? Result { get; set; }

        /// <summary>
        ///     Текст ошибки
        /// </summary>
        public string? FailedMessage { get; set; }
    }
}
