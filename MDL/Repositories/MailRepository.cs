using MDL.Interfaces;
using MDL.Models;
using Newtonsoft.Json;

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

            if(!_db.Mails.Any())
            {
                FillDB();
            }
        }

        private void FillDB()
        {
            var random = new Random();
            for (var i = 1; i < 11; i++)
            {
                var recipientsNumber = random.Next(1, 4);
                var recipients = new[] { "Ваня", "Вася", "Петя", "Федя" };
                var containException = random.Next(2) == 1;

                var mail = new Mail
                {
                    Subject = $"Тема №{i}",
                    Body = "Какой-то тестовый текст, возможно, с тегами",
                    Recipients = JsonConvert.SerializeObject(recipients.Take(recipientsNumber)),
                    Result = containException ? "Failed" : "OK",
                    FailedMessage = containException ? "TestException: Какое-то тестовое описание..." : null
                };
                _db.Add(mail);
            }
            _db.SaveChanges();
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
