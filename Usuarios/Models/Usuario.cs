using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Usuarios.Models;

public class Usuario
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Nombre { get; set; } = null!;
    [Required]
    [MaxLength(100)]
    public string Apellido { get; set; } = null!;
    [Required]
    [MaxLength(100)]
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
