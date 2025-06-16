namespace QuickShop.MVC.Models
{
    public class RubroDTO
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public List<LocalDTO>? Locales { get; set; }
    }
}