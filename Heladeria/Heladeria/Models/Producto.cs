using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Heladeria.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        public int NombreProducto { get; set; }
        public int ProovedorId { get; set; }
        public Decimal UnitPrice { get; set; } = 0;
        public string Package { get; set; }
        public bool IsDiscontinued { get; set; } = false;
        [ForeignKey("ProovedorId")]
        public Proovedor Proovedor { set; get; }
        public ICollection<OrdenarItems> OrdenarItems { get; set; }
    }
}
