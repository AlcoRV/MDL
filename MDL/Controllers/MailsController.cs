using MDL.Interfaces;
using MDL.Models;
using MDL.Tools;
using Microsoft.AspNetCore.Mvc;

namespace MDL.Controllers
{
    /// <summary>
    ///     Контроллер для работы с почтовыми сообщениями
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public sealed class MailsController : ControllerBase
    {
        private readonly IRepository<Mail> _mailRepository;

        /// <summary>
        ///     Конструктор почтового контроллера
        /// </summary>
        /// <param name="mailRepository">Репозиторий с сообщениями</param>
        public MailsController(IRepository<Mail> mailRepository)
        {
            _mailRepository = mailRepository;
        }

        /// <summary>
        ///     Get-метод, предоставляющий перечень всех отправленных сообщений за всё время в порядке от новых к старым
        /// </summary>
        /// <returns>Перечень сообщений, отсортированный по дате</returns>
        [HttpGet(Name = "GetMails")]
        public IEnumerable<Mail> Get()
        {
            return _mailRepository.All.OrderByDescending(it => it.Date);
        }

        /// <summary>
        ///     Post-метод, отправляющий сообщения и складирующий каждую попытку отправки сообщений в БД
        /// </summary>
        /// <param name="mail">Сообщение</param>
        /// <returns>Статус HTTP-запроса</returns>
        [HttpPost(Name = "PostMails")]
        public StatusCodeResult Post(Mail mail)
        {
            if(mail == null || string.IsNullOrEmpty(mail.Subject) || string.IsNullOrEmpty(mail.Body) || mail.Recipients == null) {
                mail.Result = CommonConstants.Mail.ResultFailed;
                mail.FailedMessage = CommonConstants.Mail.NotEnoughDataError; 
            }
            else
            {
                new MailManager().SendMessages(mail);
            }

            _mailRepository.Add(mail);

            if(mail.Result.Equals(CommonConstants.Mail.ResultOK))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
