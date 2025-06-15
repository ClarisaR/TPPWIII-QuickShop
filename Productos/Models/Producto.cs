using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Productos.Models
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        public string Imagen { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        public string Descripcion { get; set; } = null!;

        [Required]
        public double Precio { get; set; }

        public Categoria Categoria { get; set; } = null!;

        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }

        public int LocalId { get; set; }
        public Local Local { get; set; } = null!;

        public ICollection<Variante> Variantes { get; set; } = [];
    }
}
