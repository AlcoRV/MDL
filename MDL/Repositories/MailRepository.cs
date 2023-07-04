using MDL.DB;
using MDL.Interfaces;
using MDL.Models;

namespace MDL.Repositories
{
    /// <summary>
    ///     Репозиторий почтовых сообщений
    /// </summary>
    public sealed class MailRepository : IRepository<Mail>
    {
        private readonly MDLContext _db;

        /// <summary>
        ///     Конструктор репозитория
        /// </summary>
        /// <param name="db">Контекст БД</param>
        public MailRepository(MDLContext db)
        {
            _db = db;
        }

        /// <summary>
        ///     Свойство, предоставляющее полный перечень почтовых сообщений в БД
        /// </summary>
        public IEnumerable<Mail> All => _db.Mails;

        /// <summary>
        ///     Метод, добавляющий сообщение в БД
        /// </summary>
        /// <param name="entity">Сообщение</param>
        public void Add(Mail entity)
        {
            _db.Add(entity);
            _db.SaveChanges();
        }
    }
}
