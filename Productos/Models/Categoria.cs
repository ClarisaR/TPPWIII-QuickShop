using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Productos.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Nombre { get; set; }

        public ICollection<Producto> Productos { get; set; }
    }
}
