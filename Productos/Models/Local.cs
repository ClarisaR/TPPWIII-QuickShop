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
        [MaxLength(50)]
        public string Nombre { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        public string Descripcion { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        public string? Imagen { get; set; }

        public Rubro Rubro { get; set; } = null!;

        [ForeignKey("Rubro")]
        public int RubroId { get; set; }

        public Direccion Direccion { get; set; } = null!;

        [ForeignKey("Direccion")]
        public int DireccionId { get; set; }

        public ICollection<Producto> Productos { get; set; } = null!;
    }
}
