using System.Text.Json;
using QuickShop.MVC.Models;

namespace QuickShop.MVC.Services
{
    public interface IProductoServicio
    {
        Task<List<ProductoDTO>> ObtenerProductos();

        Task<ProductoDTO> ObtenerProducto(int id);

        Task<List<ProductoDTO>> ObtenerProductosPorNombre(string nombre);

        Task<List<ProductoDTO>> ObtenerProductosPorRubro(string rubro);
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
    }
}
