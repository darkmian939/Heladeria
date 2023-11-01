using System.ComponentModel.DataAnnotations;

namespace Heladeria.Models
{

    public class Customer
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(64)]
        public string FirstName { get; set; }

        [MaxLength(64)]
        public string LastName { get; set; } = string.Empty;

        [MaxLength(128)]
        public string City { get; set; }

        [MaxLength(128)]
        public string Country { get; set; } = string.Empty;

        [MaxLength(16)]
        public string Phone { get; set; }

    public ICollection<Order>? Orders { get; set; }

}

}
