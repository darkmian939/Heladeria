using System.ComponentModel.DataAnnotations;

namespace Heladeria.Models
{
    public class OrdenCompra
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        public Guid OrderNumber { get; set; } = Guid.NewGuid(); 

        [Required]
        public int ClienteId { get; set; }

        public decimal TotalAcumulado { get; set; } = 0;

        public ICollection<Producto> Productos { get; set; }



        // Propiedad de navegación para la relación con productos (relación muchos a muchos)
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<OrdenarItems> OrdenarItems { get; set; }
    }

}
