namespace Heladeria.Models
{

    public class Cliente
    {
        public int Id { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; } = string.Empty;
        public string Apellido { get; set; }
        public string Ciudad { get; set; } = string.Empty;
        public string Pais { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }

    public ICollection<OrdenCompra>? OrdenCompra { get; set; }

}

}
