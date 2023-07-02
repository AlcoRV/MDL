using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDL.Models
{
    public sealed class Mail
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Date { get; set; } = DateTime.Now;

        [StringLength(50)]
        public string Subject { get; set; }

        public string Body { get; set; }

        [StringLength(150)]
        public string Recipients { get; set; }

        [StringLength(10)]
        public string? Result { get; set; }

        [StringLength(100)]
        public string? FailedMessage { get; set; }
    }
}
