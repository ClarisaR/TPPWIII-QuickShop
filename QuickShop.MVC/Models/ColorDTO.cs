namespace QuickShop.MVC.Models
{
    public class ColorDTO
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public List<VarianteDTO>? Variantes { get; set; } 
    }
}