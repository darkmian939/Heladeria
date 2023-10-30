using Heladeria.Models;
using Microsoft.EntityFrameworkCore;

namespace Heladeria.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)

            : base(options)

        {



        }

        public DbSet<Proovedor> proovedors { get; set; }
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<OrdenCompra> ordenCompras { get; set; }
        public DbSet<OrdenarItems> OrdenarItems { get; set; }
        public DbSet<Producto> productos { get; set; }


    }
}
