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

        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Products> Products { get; set; }


    }
}
