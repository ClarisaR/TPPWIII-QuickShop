using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Pedidos.Models;

public class PedidoProducto
{
    [Key]
    [Column(Order = 0)]
    public int IdPedido { get; set; }

    [Key]
    [Column(Order = 1)]
    public int IdProducto { get; set; }

    public int CantidadProductos { get; set; }
    public decimal PrecioUnitario { get; set; }
}
