using Microsoft.EntityFrameworkCore;
using Productos.Data;
using Productos.Models;

namespace Productos.Services
{
    public interface IProductoService
    {
        Task<List<Producto>> GetProductos();
        Task<Producto> GetProducto(int id);
        Task<Producto> GetProductoPorNombre(string nombre);
        Task<List<Producto>> GetProductosPorRubro(string rubro);
    }

    public class ProductoService : IProductoService
    {
        private readonly ProductoDbContext _context;
        public ProductoService(ProductoDbContext _context)
        {
            this._context = _context;
        }

        public async Task<Producto> GetProducto(int id)
        {
            var producto = await _context.Productos
                .Include(p => p.Variantes)
                .Include(p => p.Local)
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(p => p.Id == id);

            return producto ?? throw new Exception($"El producto con ID = {id} no existe");
        }

        public async Task<Producto> GetProductoPorNombre(string nombre)
        {
            var producto = await _context.Productos
                .Include(p => p.Variantes)
                .Include(p => p.Local)
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(p => p.Nombre == nombre);

            return producto ?? throw new Exception($"El producto {nombre} no fue encontrado.");
        }

        public async Task<List<Producto>> GetProductos()
        {
            return await _context.Productos
                .Include(p => p.Local)
                .Include(p => p.Categoria)
                .Include(p => p.Variantes)
                .ToListAsync();
        }

        public async Task<List<Producto>> GetProductosPorRubro(string rubro)
        {
            return await _context.Productos
                .Include(p => p.Local)
                .Include(p => p.Categoria)
                .Include(p => p.Variantes)
                .Where(p => p.Local.Rubro.Nombre == rubro)
                .ToListAsync();
        }
    }
}
