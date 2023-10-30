using System.ComponentModel.DataAnnotations;

namespace Heladeria.Models
{
    public class Proovedor
    {
        [Key]
        public int Id { get; set; }
        public string NombreCompañia { get; set; }
        public string NombreContacto { get; set; }
        public string TituloContacto { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        public ICollection<Producto>? Productos { get; set; }


    }
}
