using QuickShop.MVC.Models;
using System.Text.Json;

namespace QuickShop.MVC.Services
{
    public interface ILocalServicio
    {
        Task<List<LocalDTO>> ObtenerLocales();
        Task<LocalDTO> ObtenerLocalConProductos(int id);
    }

    public class LocalServicio : ILocalServicio
    {
        private readonly HttpClient _httpClient;
        private JsonSerializerOptions _jsonOptions;
        private readonly string _url;

        public LocalServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _url = "http://productos-api:8080/api/Locales";
        }

        public async Task<List<LocalDTO>> ObtenerLocales()
        {
            var response = await _httpClient.GetAsync($"{_url}");
            if (!response.IsSuccessStatusCode) return null;

            var json = await response.Content.ReadAsStringAsync();
            var locales = JsonSerializer.Deserialize<List<LocalDTO>>(json, _jsonOptions);
            return locales;
        }

        public async Task<LocalDTO> ObtenerLocalConProductos(int id)
        {
            var response = await _httpClient.GetAsync($"{_url}/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var json = await response.Content.ReadAsStringAsync();
            var local = JsonSerializer.Deserialize<LocalDTO>(json, _jsonOptions);
            return local;
        }
    }
}
