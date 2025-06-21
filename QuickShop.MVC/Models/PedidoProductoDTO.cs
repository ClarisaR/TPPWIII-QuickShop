
namespace QuickShop.MVC.Models
{
    public class PedidoProductoDTO
    {
        public int IdPedido { get; set; }

        public int IdProducto { get; set; }

        public int CantidadProductos { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
