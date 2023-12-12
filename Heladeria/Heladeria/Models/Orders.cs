using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Heladeria.Models
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public DateTime OrderDate { get; set; } = DateTime.Now;
     

        public Guid OrderNumber { get; set; } = Guid.NewGuid(); 

        [Required]
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; } = 0;

        [ForeignKey("CustomerId")]

        public Customer? Customer { get; set; }
        public virtual ICollection<OrderItems>? OrderItems { get; set; }
    }

}
