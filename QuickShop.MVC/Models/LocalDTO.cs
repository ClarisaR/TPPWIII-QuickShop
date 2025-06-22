namespace QuickShop.MVC.Models
{
    public class LocalDTO
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public string? Imagen { get; set; }

        public RubroDTO? Rubro { get; set; }

        public int? RubroId { get; set; }

        public DireccionDTO? Direccion { get; set; }

        public int DireccionId { get; set; }

        public ICollection<ProductoDTO>? Productos { get; set; }

    }
}