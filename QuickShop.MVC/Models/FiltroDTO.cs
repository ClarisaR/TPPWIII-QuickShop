namespace QuickShop.MVC.Models
{
    public class FiltroDTO
    {
        public string[] Categorias { get; set; } = Array.Empty<string>();
        public string[] Colores { get; set; } = Array.Empty<string>();
        public string[] Talles { get; set; } = Array.Empty<string>();
        public string[] Rubros { get; set; } = Array.Empty<string>();

        public string[] Locales { get; set; } = Array.Empty<string>();

        public double PrecioMinimo { get; set; } = 0;

        public double PrecioMaximo { get; set; } = 1000000D;

    }
}
