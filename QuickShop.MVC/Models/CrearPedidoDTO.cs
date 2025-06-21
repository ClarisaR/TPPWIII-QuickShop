namespace QuickShop.MVC.Models
{
    public class CrearPedidoDTO
    {
        public int IdUsuario { get; set; }
        public string Estado { get; set; }
        public string DireccionHasta { get; set; }
        public string DireccionDesde { get; set; }
        public List<CrearPedidoProductoDTO> PedidoProductos { get; set; }
    }
}
