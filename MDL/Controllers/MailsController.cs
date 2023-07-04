using MDL.Interfaces;
using MDL.Models;
using MDL.Tools;
using MDL.ViewModels;
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
        private readonly IMailManager _mailManager;

        /// <summary>
        ///     Конструктор почтового контроллера
        /// </summary>
        /// <param name="mailRepository">Репозиторий с сообщениями</param>
        public MailsController(IRepository<Mail> mailRepository, IMailManager mailManager)
        {
            _mailRepository = mailRepository;
            _mailManager = mailManager;
        }

        /// <summary>
        ///     Get-метод, предоставляющий перечень всех отправленных сообщений за всё время в порядке от новых к старым
        /// </summary>
        /// <returns>Перечень сообщений, отсортированный по дате</returns>
        [HttpGet(Name = "GetMails")]
        public IEnumerable<MailViewModel> Get()
        {
            return _mailRepository.All.Select(it => it.ToMailViewModel()).OrderByDescending(it => it.Date);
        }

        /// <summary>
        ///     Post-метод, отправляющий сообщения и складирующий каждую попытку отправки сообщений в БД
        /// </summary>
        /// <param name="mailViewModel">Сообщение</param>
        /// <returns>Статус HTTP-запроса</returns>
        [HttpPost(Name = "PostMails")]
        public StatusCodeResult Post(MailViewModel mailViewModel)
        {
            var mail = new Mail()
            {
                Subject = mailViewModel.Subject ?? string.Empty,
                Body = mailViewModel.Body ?? string.Empty,
                Recipients = mailViewModel.Recipients ?? string.Empty
            };

            if (mailViewModel == null || string.IsNullOrEmpty(mailViewModel.Subject?.Trim()) || string.IsNullOrEmpty(mailViewModel.Body?.Trim()) || string.IsNullOrEmpty(mailViewModel.Recipients?.Trim())) {
                mail.FailedMessage = CommonConstants.Mail.NotEnoughDataError; 
            }
            else
            {
                _mailManager.SendMessages(mail);
            }

            _mailRepository.Add(mail);

            if(mail.Result == CommonConstants.Mail.Result.OK)
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
