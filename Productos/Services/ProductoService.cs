using Microsoft.EntityFrameworkCore;
using Productos.Data;
using Productos.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Productos.Services
{
    public interface IProductoService
    {
        Task<List<Producto>> GetProductos();
        Task<Producto> GetProducto(int id);
        Task<List<Producto>> GetProductosPorNombre(string nombre);
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

        public async Task<List<Producto>> GetProductosPorNombre(string nombre)
        {
            var productos = await _context.Productos
        .Include(p => p.Variantes)
        .Include(p => p.Local)
        .Include(p => p.Categoria)
        .Where(p => p.Nombre.Contains(nombre))
        .ToListAsync();

            return productos.Any() ? productos : throw new Exception($"El producto '{nombre}' no fue encontrado.");
        }

        public async Task<List<Producto>> GetProductos()
        {
            var productos = await _context.Productos
                .Include(p => p.Local)
                .Include(p => p.Categoria)
            .Include(p => p.Variantes)
            .ToListAsync();

            return productos.Any() ? productos: throw new Exception($"No se encontraron productos.");
        }

        public async Task<List<Producto>> GetProductosPorRubro(string rubro)
        {
            var productosPorRubro = await _context.Productos
                .Include(p => p.Local)
                .Include(p => p.Categoria)
                .Include(p => p.Variantes)
                .Where(p => p.Local.Rubro.Nombre == rubro)
                .ToListAsync();

            return productosPorRubro.Any() ? productosPorRubro : throw new Exception("No se encontraron productos por rubro.");
        }
    }
}
