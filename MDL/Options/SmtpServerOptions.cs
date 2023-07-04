namespace MDL.Options
{
    /// <summary>
    ///     Настройки SMTP-сервера
    /// </summary>
    public sealed class SmtpServerOptions
    {
        /// <summary>
        ///     Название секции конфигурации
        /// </summary>
        public const string SmtpServer = "SmtpServer";

        /// <summary>
        ///     Отображаемое имя почтового ящика отправки
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///     Адрес сервера почтового сервиса
        /// </summary>
        public string Client { get; set; }
        /// <summary>
        ///     Почтовый адрес отправителя
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        ///     Персональный ключ SMTP-сервера
        /// </summary>
        public string Password { get; set; }
    }
}
