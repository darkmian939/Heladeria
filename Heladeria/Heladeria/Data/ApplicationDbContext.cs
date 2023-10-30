using Microsoft.EntityFrameworkCore;

namespace Heladeria.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)

            : base(options)

        {



        }
    }
}
