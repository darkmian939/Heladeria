using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Heladeria.Models
{
    public class OrdenarItems
    {
        [Key]
        public int Id { get; set; }
        public int OrdenId { get; set; }
        public int ProductoId { get; set; }
        public Decimal UnitPrice { get; set; } = 0;
        public int Quantity { get; set; } = 1;
        [ForeignKey("OrdenId")]

        public virtual OrdenCompra OrdenCompra { get; set; }
        [ForeignKey("ProductoId")]
        public virtual Producto Producto { get; set; }

    }
}
