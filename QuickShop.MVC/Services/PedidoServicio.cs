using System.Text.Json;
using QuickShop.MVC.Models;

namespace QuickShop.MVC.Services
{
    public interface IPedidoServicio
    {
        Task<List<PedidoDTO>> ObtenerPedidosDeUsuario(int idUsuario);
        Task<PedidoDTO> ObtenerPedido(int id);
        Task<int?> CrearPedido(CrearPedidoDTO pedido);
        Task<List<PedidoDTO>> ObtenerTodosLosPedidos();
        Task<List<PedidoProductoDTO>> ObtenerDetallesPedido(int id);

    }
    public class PedidoServicio : IPedidoServicio
    {
        private readonly HttpClient httpClient;
        private readonly string url = "http://pedidos-api:8080/api/Pedidos";
        private JsonSerializerOptions opcionesSerializacion = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        public PedidoServicio(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<PedidoDTO>> ObtenerPedidosDeUsuario(int idUsuario)
        {
            var response = await httpClient.GetAsync($"{url}/usuario/{idUsuario}");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            else
            {
                var json = await response.Content.ReadAsStringAsync();
                var pedidos = JsonSerializer.Deserialize<List<PedidoDTO>>(json, opcionesSerializacion);

                return pedidos;
            }
        }

        public async Task<PedidoDTO> ObtenerPedido(int id)
        {
            var response = await httpClient.GetAsync($"{url}/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            else
            {
                var json = await response.Content.ReadAsStringAsync();
                var pedido = JsonSerializer.Deserialize<PedidoDTO>(json, opcionesSerializacion);
                return pedido;
            }
        }

        public async Task<int?> CrearPedido(CrearPedidoDTO pedido)
        {
            var json = JsonSerializer.Serialize(pedido, opcionesSerializacion);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(url, content);
            if (!response.IsSuccessStatusCode)
                return null;

            var responseJson = await response.Content.ReadAsStringAsync();

            try
            {
                using var doc = JsonDocument.Parse(responseJson);
                if (doc.RootElement.TryGetProperty("id", out var idElement))
                {
                    return idElement.GetInt32();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer el ID del pedido: " + ex.Message);
            }

            return null;
        }

        public async Task<List<PedidoDTO>> ObtenerTodosLosPedidos()
        {
            var response = await httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            else
            {
                var json = await response.Content.ReadAsStringAsync();
                var pedidos = JsonSerializer.Deserialize<List<PedidoDTO>>(json, opcionesSerializacion);
                return pedidos;
            }
        }

        public async Task<List<PedidoProductoDTO>> ObtenerDetallesPedido(int id)
        {
            var response = await httpClient.GetAsync($"{url}/detalles/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            else
            {
                var json = await response.Content.ReadAsStringAsync();
                var detalles = JsonSerializer.Deserialize<List<PedidoProductoDTO>>(json, opcionesSerializacion);
                return detalles;
            }
        }


    }
}
