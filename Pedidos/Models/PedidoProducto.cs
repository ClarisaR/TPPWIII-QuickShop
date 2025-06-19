using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Pedidos.Models
{
    public class PedidoProducto
    {
        [Key]
        [Column(Order = 0)]
        public int IdPedido { get; set; }

        [ForeignKey("IdPedido")]
        public Pedido Pedido { get; set; }

        [Key]
        [Column(Order = 1)]
        public int IdProducto { get; set; }


        [Range(1, int.MaxValue)]
        public int CantidadProductos { get; set; }

        [Range(0, double.MaxValue)]
        public decimal PrecioUnitario { get; set; }
    }
}
