using QuickShop.MVC.Models;

namespace QuickShop.MVC.Services
{
    public interface IUsuarioServicio
    {
        Task<bool> RegistrarUsuario(Usuario usuario);
        Task<string?> LoginUsuario(LoginDTO login);
    }

    public class UsuarioServicio : IUsuarioServicio
    {

        private readonly HttpClient httpClient;
        public UsuarioServicio(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<bool> RegistrarUsuario(Usuario usuario)
        {
            var response = await httpClient.PostAsJsonAsync("http://autenticacion-api:8080/api/Autenticacion/register", usuario);
            return response.IsSuccessStatusCode;
        }

        public async Task<string?> LoginUsuario(LoginDTO login)
        {
            var response = await httpClient.PostAsJsonAsync("http://autenticacion-api:8080/api/Autenticacion/login", login);
            if (!response.IsSuccessStatusCode)
                return null;

            var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
            return loginResponse?.Token;
        }
    }
}
