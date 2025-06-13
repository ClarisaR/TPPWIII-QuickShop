using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Productos.Models
{
    public class Rubro
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Nombre { get; set; }

        public ICollection<Local> Locales { get; set; }
    }
}
