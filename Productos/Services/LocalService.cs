using Microsoft.EntityFrameworkCore;
using Productos.Data;
using Productos.Models;

namespace Productos.Services
{
    public interface ILocalService
    {
        Task<List<Local>> ObtenerLocales();
        Task<Local?> ObtenerLocalPorId(int id);
        Task<Local> CrearLocal(Local local);
        Task<bool> EliminarLocal(int id);
        Task<List<Local>> ObtenerLocalesPorNombre(string nombre);
    }

    public class LocalService : ILocalService
    {
        private readonly ProductoDbContext _context;

        public LocalService(ProductoDbContext context)
        {
            _context = context;
        }

        public async Task<List<Local>> ObtenerLocales()
        {
            var locales = await _context.Locales
                .Include(l => l.Direccion)
                .Include(l => l.Rubro)
                .Select(l => new Local
                {
                    Id = l.Id,
                    Nombre = l.Nombre,
                    Descripcion = l.Descripcion,
                    Imagen = l.Imagen,
                    Rubro = new Rubro
                    {
                        Id = l.Rubro.Id,
                        Nombre = l.Rubro.Nombre
                        // No incluimos Rubro.Locales
                    },
                    Direccion = l.Direccion
                })
                .ToListAsync();
            return locales.Any() ? locales : throw new Exception($"No se encontraron locales.");
        }

        public async Task<Local?> ObtenerLocalPorId(int id)
        {
            return await _context.Locales
                .Include(l => l.Productos)
                .Include(l => l.Direccion)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<Local> CrearLocal(Local local)
        {
            _context.Locales.Add(local);
            await _context.SaveChangesAsync();
            return local;
        }

        public async Task<bool> EliminarLocal(int id)
        {
            var local = await _context.Locales.FindAsync(id);
            if (local == null) return false;

            _context.Locales.Remove(local);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Local>> ObtenerLocalesPorNombre(string nombre)
        {
            var locales = await _context.Locales
                            .Include(l => l.Rubro)
                            .Where(l => l.Nombre.Contains(nombre))
                            .ToListAsync();
            return locales;
        }
    }
}
