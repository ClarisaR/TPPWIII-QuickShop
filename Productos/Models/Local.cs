using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Productos.Models
{
    public class Local
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(200)]
        public string Descripcion { get; set; }

        public Rubro Rubro { get; set; }

        public int RubroId { get; set; }

        public ICollection<Producto> Productos { get; set; }
    }
}
