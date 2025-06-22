namespace QuickShop.MVC.Models
{
    public class DetallePedidoViewModel
    {
        public string NombreProducto { get; set; } = null!;
        public string ImagenProducto { get; set; } = null!;
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal => PrecioUnitario * Cantidad;
    }
}
