using Microsoft.EntityFrameworkCore;
using Usuarios.Models;

namespace Usuarios.Data
{
    public static class DbInitializer
    {
        public static void Seed(UsuarioDbContext context)
        {
            var usuario = new Usuario
            {
                Nombre = "Admin",
                Apellido = "Sistema",
                Email = "admin@ejemplo.com",
                Contrasenia = HashPassword("admin123"),
                Telefono = 1234567890,
                Direccion = "Oficina Central"
            };

            Console.WriteLine($"Insertando usuario: {usuario.Nombre} - {usuario.Email}");

            context.Usuarios.Add(usuario);
            context.SaveChanges();
        }

        private static string HashPassword(string password)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }

    }
}
