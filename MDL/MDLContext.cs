using MDL.Models;
using Microsoft.EntityFrameworkCore;

namespace MDL
{
    public class MDLContext: DbContext
    {
        public MDLContext(DbContextOptions<MDLContext> options) : base(options) { }

        public DbSet<Mail> Mails { get; set; }
    }
}
