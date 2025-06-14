using System.ComponentModel.DataAnnotations;

namespace Productos.Models
{
    public class Talle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Nombre { get; set; } = null!;

        public ICollection<Variante> Variantes { get; set; } = [];
    }
}
