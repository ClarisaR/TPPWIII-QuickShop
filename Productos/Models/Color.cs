using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Productos.Models
{
    public class Color
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Nombre { get; set; }

        public ICollection<Variante> Variantes { get; set; }
    }
}
