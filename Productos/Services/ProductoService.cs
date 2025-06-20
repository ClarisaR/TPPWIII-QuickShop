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

        Task<List<Producto>> GetProductosPorColor(string color);
        Task<List<Producto>> GetProductosPorTalle(string talle);
        Task<List<Producto>> GetProductosSimilares(int id);
        Task<List<Producto>> GetProductosPorLocal(int id);
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

            producto.Variantes = await _context.Variantes
                                .Include(v => v.Color)
                                .Include(v => v.Talle)
                                .Where(v => v.ProductoId == id)
                                .ToListAsync();

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

            productos.ForEach(p =>
            {
                p.Variantes = _context.Variantes
                            .Include(v => v.Color)
                            .Include(v => v.Talle)
                            .Where(v => v.ProductoId == p.Id)
                            .ToList();
            });

            return productos.Any() ? productos : throw new Exception($"El producto '{nombre}' no fue encontrado.");
        }

        public async Task<List<Producto>> GetProductos()
        {
            var productos = await _context.Productos
                            .Include(p => p.Local)
                            .Include(p => p.Categoria)
                            .Include(p => p.Variantes)
                            .ToListAsync();

            productos.ForEach(p =>
            {
                p.Variantes = _context.Variantes
                            .Include(v => v.Color)
                            .Include(v => v.Talle)
                            .Where(v => v.ProductoId == p.Id)
                            .ToList();
            });

            return productos.Any() ? productos : throw new Exception($"No se encontraron productos.");
        }

        public async Task<List<Producto>> GetProductosPorRubro(string rubro)
        {
            var productosPorRubro = await _context.Productos
                                    .Include(p => p.Local)
                                    .Include(p => p.Categoria)
                                    .Include(p => p.Variantes)
                                    .Where(p => p.Local.Rubro.Nombre == rubro)
                                    .ToListAsync();

            productosPorRubro.ForEach(p =>
            {
                p.Variantes = _context.Variantes
                            .Include(v => v.Color)
                            .Include(v => v.Talle)
                            .Where(v => v.ProductoId == p.Id)
                            .ToList();
            });


            return productosPorRubro.Any() ? productosPorRubro : throw new Exception("No se encontraron productos por rubro.");
        }

        public async Task<List<Producto>> GetProductosPorColor(string color)
        {
            var productosPorColor = await _context.Productos.Include(p => p.Variantes)
                                    .Include(p => p.Local)
                                    .Include(p => p.Categoria)
                                    .Where(p => p.Variantes.Any(v => v.Color.Nombre == color))
                                    .ToListAsync();

            productosPorColor.ForEach(p =>
            {
                p.Variantes = _context.Variantes
                            .Include(v => v.Color)
                            .Include(v => v.Talle)
                            .Where(v => v.ProductoId == p.Id)
                            .ToList();
            });
            return productosPorColor.Any() ? productosPorColor : throw new Exception($"No se encontraron productos con el color '{color}'.");
        }

        public async Task<List<Producto>> GetProductosPorTalle(string talle)
        {
            var productosPorTalle = await _context.Productos
                                    .Include(p => p.Variantes)
                                    .Include(p => p.Local)
                                    .Include(p => p.Categoria)
                                    .Where(p => p.Variantes.Any(v => v.Talle.Nombre == talle))
                                    .ToListAsync();
            productosPorTalle.ForEach(p =>
            {
                p.Variantes = _context.Variantes
                            .Include(v => v.Color)
                            .Include(v => v.Talle)
                            .Where(v => v.ProductoId == p.Id)
                            .ToList();
            });
            return productosPorTalle.Any() ? productosPorTalle : throw new Exception($"No se encontraron productos con el talle '{talle}'.");
        }

        public async Task<List<Producto>> GetProductosSimilares(int id)
        {
            var productosSimilares = await _context.Productos
                                    .Include(p => p.Variantes)
                                    .Include(p => p.Local)
                                    .Include(p => p.Categoria)
                                    .Where(p => p.Categoria.Id == id)
                                    .Take(5)
                                    .ToListAsync();

            return productosSimilares.Any()
                ? productosSimilares
                : throw new Exception($"No se encontraron productos similares a la categoría con ID = {id}.");
        }

        public async Task<List<Producto>> GetProductosPorLocal(int id)
        {
            var productosPorLocal = await _context.Productos
                                    .Include(p => p.Variantes)
                                    .Include(p => p.Local)
                                    .Include(p => p.Categoria)
                                    .Where(p => p.LocalId == id)
                                    .Take(5)
                                    .ToListAsync();

            return productosPorLocal.Any()
                ? productosPorLocal
                : throw new Exception($"No se encontraron productos para el local con ID = {id}.");
        }
    }
}
