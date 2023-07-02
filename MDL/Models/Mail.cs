using System.ComponentModel.DataAnnotations;

namespace MDL.Models
{
    /// <summary>
    ///     Модель почтового сообщения
    /// </summary>
    public sealed class Mail
    {
        /// <summary>
        ///     Id сообщения
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();
        /// <summary>
        ///     Дата отправки
        /// </summary>
        public DateTime Date { get; set; } = DateTime.Now;

        /// <summary>
        ///     Тема сообщения
        /// </summary>
        [StringLength(50)]
        public string Subject { get; set; }

        /// <summary>
        ///     Содержание сообщения
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        ///     Список получателей в формате JSON
        /// </summary>
        [StringLength(150)]
        public string Recipients { get; set; }

        /// <summary>
        ///     Результат отправки сообщений
        /// </summary>
        [StringLength(10)]
        public string? Result { get; set; }

        /// <summary>
        ///     Текст ошибки
        /// </summary>
        [StringLength(100)]
        public string? FailedMessage { get; set; }
    }
}
