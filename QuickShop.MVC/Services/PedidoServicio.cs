using System.Text.Json;
using QuickShop.MVC.Models;

namespace QuickShop.MVC.Services
{
    public interface IPedidoServicio
    {
        Task<List<PedidoDTO>> ObtenerPedidosDeUsuario(int idUsuario);
        Task<PedidoDTO> ObtenerPedido(int id);
        Task<bool> CrearPedido(CrearPedidoDTO pedido);
        Task<List<PedidoDTO>> ObtenerTodosLosPedidos();

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

        public async Task<bool> CrearPedido(CrearPedidoDTO pedido)
        {
            var json = JsonSerializer.Serialize(pedido, opcionesSerializacion);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, content);
            return response.IsSuccessStatusCode;
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


    }
}
