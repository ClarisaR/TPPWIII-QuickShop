using System.ComponentModel.DataAnnotations;

namespace Usuarios.Models.DTO
{
    public class CrearUsuarioDTO
    {
        [Required]                      
        [MaxLength(100)]
        public string Nombre { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        public string Apellido { get; set; } = null!;

        [Required]                     
        [EmailAddress]                 
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Contrasenia { get; set; } = null!;
        [Required]
        public long Telefono { get; set; }
        [Required]
        [MaxLength(100)]
        public string Direccion { get; set; } = null!;
    }

}
