using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Heladeria.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string ProductName { get; set; }
        [Required]
        public int SupplierId { get; set; }
        public Decimal UnitPrice { get; set; } = 0;
        [MaxLength(64)]
        public string Package { get; set; }
        public bool IsDiscontinued { get; set; } = false;
        [ForeignKey("SupplierId")]
        public Suppliers Supplier { set; get; }
        public ICollection<OrderItems> OrderItems { get; set; }
    }
}
