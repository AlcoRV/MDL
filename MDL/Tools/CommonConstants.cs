﻿namespace MDL.Tools
{
    /// <summary>
    ///     Общие константы
    /// </summary>
    public static class CommonConstants
    {
        /// <summary>
        ///     Константы почтовых сообщений
        /// </summary>
        public static class Mail
        {
            /// <summary>
            ///     Рассылка писем прошла успешно
            /// </summary>
            public const string ResultOK = "OK";
            /// <summary>
            ///     Рассылка писем прошла с ошибкой
            /// </summary>
            public const string ResultFailed = "Failed";
            /// <summary>
            ///     Ошибка, недостаточно входных данных
            /// </summary>
            public const string NotEnoughDataError = "Not enough data. Need subject, body and recipients.";
        }
    }
}