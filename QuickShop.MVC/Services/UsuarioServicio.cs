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
        private readonly IHttpContextAccessor httpContext;
        public UsuarioServicio(HttpClient httpClient, IHttpContextAccessor httpContext)
        {
            this.httpClient = httpClient;
            this.httpContext = httpContext;
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
