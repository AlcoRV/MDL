using MDL.Interfaces;
using MDL.Models;
using MDL.Repositories;
using MDL.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MDL.Controllers
{
    /// <summary>
    ///     Контроллер для работы с почтовыми-сообщениями
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MailsController : ControllerBase
    {
        private readonly IRepository<Mail> _mailRepository;

        public MailsController(IRepository<Mail> mailRepository)
        {
            _mailRepository = mailRepository;
        }

        [HttpGet(Name = "GetMails")]
        public IEnumerable<Mail> Get()
        {
            return _mailRepository.All;
        }

        [HttpPost(Name = "PostMails")]
        public StatusCodeResult Post(Mail mail)
        {
            if(mail == null || string.IsNullOrEmpty(mail.Subject) || string.IsNullOrEmpty(mail.Body) || mail.Recipients == null) { return BadRequest(); }

            new MailManager().SendMessages(mail);
            _mailRepository.Add(mail);

            return Ok();
        }
    }
}
