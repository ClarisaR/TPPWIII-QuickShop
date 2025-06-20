using Microsoft.EntityFrameworkCore;
using Productos.Data;
using Productos.Dtos;
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
        Task<List<Producto>> GetProductosSimilares(int idProducto);
        Task<List<Producto>> GetProductosDelMismoLocal(int idProducto);
        Task<List<Producto>> FiltrarProductos(FiltroDTO filtro);

        Task<List<Producto>> GetProductosPorCategoria(string categoria);

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

            return producto;
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

            return productos;
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

            return productos;
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


            return productosPorRubro;
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
            return productosPorColor;
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
            return productosPorTalle;
        }

        public async Task<List<Producto>> GetProductosSimilares(int idProducto)
        {
            var producto = await _context.Productos
                                    .Include(p => p.Categoria)
                                    .FirstOrDefaultAsync(p => p.Id == idProducto);
            if (producto == null || producto.Categoria == null)
            {
                return null;
            }
            return await _context.Productos
                                    .Include(p => p.Variantes)
                                    .Include(p => p.Local)
                                    .Include(p => p.Categoria)
                                    .Where(p => p.Id != producto.Id && p.Categoria.Id == producto.Categoria.Id)
                                    .Take(5)
                                    .ToListAsync();
        }

        public async Task<List<Producto>> GetProductosDelMismoLocal(int idProducto)
        {
            var producto = await _context.Productos
                                    .Include(p => p.Local)
                                    .FirstOrDefaultAsync(p => p.Id == idProducto);

            if (producto == null || producto.Local == null)
            {
                return null;
            }
            return await _context.Productos
                                    .Include(p => p.Variantes)
                                    .Include(p => p.Local)
                                    .Include(p => p.Categoria)
                                    .Where(p => p.Id != producto.Id && p.Local.Id == producto.Local.Id)
                                    .Take(5)
                                    .ToListAsync();
        }

        public async Task<List<Producto>> FiltrarProductos(FiltroDTO filtro)
        {
            var consulta = _context.Productos
                .Include(p => p.Variantes)
                .Include(p => p.Local)
                .Include(p => p.Categoria)
                .AsQueryable();

            if (filtro.Categorias.Any())
                consulta = consulta.Where(p => filtro.Categorias.Contains(p.Categoria.Nombre));

            if (filtro.Colores.Any())
                consulta = consulta.Where(p => p.Variantes.Any(v => filtro.Colores.Contains(v.Color.Nombre)));

            if (filtro.Talles.Any())
                consulta = consulta.Where(p => p.Variantes.Any(v => filtro.Talles.Contains(v.Talle.Nombre)));

            if (filtro.Rubros.Any())
                consulta = consulta.Where(p => filtro.Rubros.Contains(p.Local.Rubro.Nombre));

            if (filtro.Locales.Any())
                consulta = consulta.Where(p => filtro.Locales.Contains(p.Local.Nombre));

            consulta = consulta.Where(p => p.Precio >= filtro.PrecioMinimo &&
                                           p.Precio <= filtro.PrecioMaximo
            );

            var productos = await consulta.ToListAsync();

            return productos;
        }
        public async Task<List<Producto>> GetProductosPorCategoria(string categoria)
        {
            var productosPorCategoria = await _context.Productos
                                    .Include(p => p.Local)
                                    .Include(p => p.Categoria)
                                    .Include(p => p.Variantes)
                                    .Where(p => p.Categoria.Nombre == categoria)
                                    .ToListAsync();

            productosPorCategoria.ForEach(p =>
            {
                p.Variantes = _context.Variantes
                            .Include(v => v.Color)
                            .Include(v => v.Talle)
                            .Where(v => v.ProductoId == p.Id)
                            .ToList();
            });


            return productosPorCategoria;
        }
    }
}
