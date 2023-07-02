using MDL.Models;
using Microsoft.EntityFrameworkCore;

namespace MDL
{
    /// <summary>
    ///     Контекст БД почтовых сообщений
    /// </summary>
    public sealed class MDLContext: DbContext
    {
        /// <summary>
        ///     Конструктор контекста
        /// </summary>
        /// <param name="options">Параметры контекста</param>
        public MDLContext(DbContextOptions<MDLContext> options) : base(options) { }

        /// <summary>
        ///     Коллекция сообщений
        /// </summary>
        public DbSet<Mail> Mails { get; set; }
    }
}
