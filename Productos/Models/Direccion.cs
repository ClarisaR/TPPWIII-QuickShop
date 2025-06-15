using System.ComponentModel.DataAnnotations;

namespace Productos.Models
{
    public class Direccion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Descripcion { get; set; } = null!;

        [Required]
        public double? Latitud { get; set; }

        [Required]
        public double? Longitud { get; set; }
    }
}
