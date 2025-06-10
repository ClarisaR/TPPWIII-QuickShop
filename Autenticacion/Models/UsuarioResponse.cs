namespace Autenticacion.Models
{
    public class UsuarioResponse
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }
        public long Telefono { get; set; }
        public string Direccion { get; set; }
    }
}
