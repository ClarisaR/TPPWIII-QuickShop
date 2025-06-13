using System.ComponentModel.DataAnnotations;

namespace Productos.Models
{
    public class Talle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Nombre { get; set; }

        public ICollection<Variante> Variantes { get; set; }
    }
}
