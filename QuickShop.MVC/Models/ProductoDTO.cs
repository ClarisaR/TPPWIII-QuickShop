namespace QuickShop.MVC.Models
{
    public class ProductoDTO
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Imagen { get; set; }

        public string? Descripcion { get; set; }

        public double? Precio {  get; set; }

        public CategoriaDTO? Categoria { get; set; }

        public int? CategoriaId { get; set; }

        public LocalDTO Local { get; set; }

        public int? LocalId { get; set; }

        public List<VarianteDTO>? Variantes { get; set; }
    }
}
