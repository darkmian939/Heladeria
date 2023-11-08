using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Heladeria.Models
{
    public class OrderItems
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public Decimal UnitPrice { get; set; } = 0;
        [Required]


        public int Quantity { get; set; } = 1;
        [ForeignKey("OrderId")]

        public Orders? OrdenCompra { get; set; }
        [ForeignKey("ProductId")]

        public Products? Product { get; set; }
        public decimal Subtotal { get; internal set; }
    }
}
