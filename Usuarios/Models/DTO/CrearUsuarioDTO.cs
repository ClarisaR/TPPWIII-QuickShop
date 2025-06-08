using System.ComponentModel.DataAnnotations;

namespace Usuarios.Models.DTO
{
    public class CrearUsuarioDTO
    {
        [Required]                      // Obligatorio
        [MaxLength(100)]
        public string Nombre { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        public string Apellido { get; set; } = null!;

        [Required]                      // Obligatorio
        [EmailAddress]                  // Validación adicional de email
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Contrasenia { get; set; } = null!;
        [Required]
        public string Telefono { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        public string Direccion { get; set; } = null!;
    }

}
