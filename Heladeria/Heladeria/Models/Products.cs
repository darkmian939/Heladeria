using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Heladeria.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string ProductName { get; set; }
        [Required]
        public int SupplierId { get; set; }
        public decimal UnitPrice { get; set; } = 0;
        [MaxLength(64)]
        public string Package { get; set; }
        public bool IsDiscontinued { get; set; } = false;
        [ForeignKey("SupplierId")]
        public Suppliers? Supplier { get; set; }
        public ICollection<OrderItems>? OrderItems { get; set; }
    }
}