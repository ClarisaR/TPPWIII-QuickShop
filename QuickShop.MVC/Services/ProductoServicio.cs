﻿using System.Text.Json;
using QuickShop.MVC.Models;

namespace QuickShop.MVC.Services
{
    public interface IProductoServicio
    {
        Task<List<ProductoDTO>> ObtenerProductos();

        Task<ProductoDTO> ObtenerProducto(int id);

        Task<List<ProductoDTO>> ObtenerProductosPorNombre(string nombre);

        Task<List<ProductoDTO>> ObtenerProductosPorRubro(string rubro);
        Task<List<ProductoDTO>> ObtenerProductosPorColor(string color);
        Task<List<ProductoDTO>> ObtenerProductosPorTalle(string talle);
        Task<List<ProductoDTO>> ObtenerProductosSimilares(int id);
        Task<List<ProductoDTO>> ObtenerProductosPorLocal(int? localId);
        Task<List<ProductoDTO>> FiltrarProductos(FiltroDTO? filtro);
        Task<List<ProductoDTO>> ObtenerProductosPorCategoria(string categoria);
        Task<List<ProductoDTO>> ObtenerProductosPorIds(List<int> ids);
        Task<List<ProductoDTO>> FiltrarProductosDesdeLista(FiltroDTO filtro, List<ProductoDTO> productosBase);
    }
    public class ProductoServicio : IProductoServicio
    {
        private readonly HttpClient _httpClient;
        private readonly string _url = "http://productos-api:8080/api/Producto";
        private JsonSerializerOptions opcionesSerializacion = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        public ProductoServicio(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }


        public async Task<ProductoDTO> ObtenerProducto(int id)
        {
            var response = await _httpClient.GetAsync($"{_url}/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var json = await response.Content.ReadAsStringAsync();
            var producto = JsonSerializer.Deserialize<ProductoDTO>(json, opcionesSerializacion);

            return producto;
        }

        public async Task<List<ProductoDTO>> ObtenerProductos()
        {
            var response = await _httpClient.GetAsync($"{_url}");
            if (!response.IsSuccessStatusCode) return null;

            var json = await response.Content.ReadAsStringAsync();
            var productos = JsonSerializer.Deserialize<List<ProductoDTO>>(json, opcionesSerializacion);

            Console.WriteLine("productos desde el servicio: " + productos[0].Nombre);
            return productos;
        }

        public async Task<List<ProductoDTO>> ObtenerProductosPorNombre(string nombre)
        {
            var response = await _httpClient.GetAsync($"{_url}/nombre/{nombre}");
            if (!response.IsSuccessStatusCode) return null;

            var json = await response.Content.ReadAsStringAsync();
            var productos = JsonSerializer.Deserialize<List<ProductoDTO>>(json, opcionesSerializacion);

            return productos;
        }

        public async Task<List<ProductoDTO>> ObtenerProductosPorRubro(string rubro)
        {
            var response = await _httpClient.GetAsync($"{_url}/rubro/{rubro}");
            if (!response.IsSuccessStatusCode) return null;

            var json = await response.Content.ReadAsStringAsync();
            var productos = JsonSerializer.Deserialize<List<ProductoDTO>>(json, opcionesSerializacion);

            return productos;
        }

        public async Task<List<ProductoDTO>> ObtenerProductosPorColor(string color)
        {
            var response = await _httpClient.GetAsync($"{_url}/color/{color}");
            if (!response.IsSuccessStatusCode) return null;
            var json = await response.Content.ReadAsStringAsync();
            var productos = JsonSerializer.Deserialize<List<ProductoDTO>>(json, opcionesSerializacion);
            return productos;
        }

        public async Task<List<ProductoDTO>> ObtenerProductosPorTalle(string talle)
        {
            var response = await _httpClient.GetAsync($"{_url}/talle/{talle}");
            if (!response.IsSuccessStatusCode) return null;
            var json = await response.Content.ReadAsStringAsync();
            var productos = JsonSerializer.Deserialize<List<ProductoDTO>>(json, opcionesSerializacion);
            return productos;
        }

        public async Task<List<ProductoDTO>> ObtenerProductosSimilares(int id)
        {
            var response = await _httpClient.GetAsync($"{_url}/similares/{id}");
            if (!response.IsSuccessStatusCode) return null;
            var json = await response.Content.ReadAsStringAsync();
            var productosSimilares = JsonSerializer.Deserialize<List<ProductoDTO>>(json, opcionesSerializacion);
            return productosSimilares;
        }

        public async Task<List<ProductoDTO>> ObtenerProductosPorLocal(int? localId)
        {
            var response = await _httpClient.GetAsync($"{_url}/local/{localId}");
            if (!response.IsSuccessStatusCode) return null;
            var json = await response.Content.ReadAsStringAsync();
            var productosPorLocal = JsonSerializer.Deserialize<List<ProductoDTO>>(json, opcionesSerializacion);
            return productosPorLocal;
        }

        public async Task<List<ProductoDTO>> FiltrarProductos(FiltroDTO? filtro)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_url}/filtrar", filtro);
            if (!response.IsSuccessStatusCode) return null;
            var json = await response.Content.ReadAsStringAsync();
            var productosFiltrados = JsonSerializer.Deserialize<List<ProductoDTO>>(json, opcionesSerializacion);
            return productosFiltrados;
        }

        public async Task<List<ProductoDTO>> ObtenerProductosPorCategoria(string categoria)
        {
            var response = await _httpClient.GetAsync($"{_url}/categoria/{categoria}");
            if (!response.IsSuccessStatusCode) return null;
            var json = await response.Content.ReadAsStringAsync();
            var productosPorCategoria = JsonSerializer.Deserialize<List<ProductoDTO>>(json, opcionesSerializacion);
            return productosPorCategoria;
        }
        public async Task<List<ProductoDTO>> ObtenerProductosPorIds(List<int> ids)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_url}/ids", ids);
            if (!response.IsSuccessStatusCode) return null;
            var json = await response.Content.ReadAsStringAsync();
            var productosPorIds = JsonSerializer.Deserialize<List<ProductoDTO>>(json, opcionesSerializacion);
            return productosPorIds;
        }

        public async Task<List<ProductoDTO>> FiltrarProductosDesdeLista(FiltroDTO filtro, List<ProductoDTO> productosBase)
        {
            var resultado = productosBase.AsEnumerable();

            if (filtro.Categorias?.Any() == true)
                resultado = resultado.Where(p => filtro.Categorias.Contains(p.Categoria?.Nombre));

            if (filtro.Colores?.Any() == true)
                resultado = resultado.Where(p => p.Variantes.Any(v => filtro.Colores.Contains(v.Color?.Nombre)));

            if (filtro.Talles?.Any() == true)
                resultado = resultado.Where(p => p.Variantes.Any(v => filtro.Talles.Contains(v.Talle?.Nombre)));

            if (filtro.Rubros?.Any() == true)
                resultado = resultado.Where(p => filtro.Rubros.Contains(p.Local?.Rubro?.ToString()));

            if (filtro.PrecioMinimo > 0)
                resultado = resultado.Where(p => p.Precio >= filtro.PrecioMinimo);

            if (filtro.PrecioMaximo < double.MaxValue)
                resultado = resultado.Where(p => p.Precio <= filtro.PrecioMaximo);

            return await Task.FromResult(resultado.ToList());
        }
    }
}
