using System.ComponentModel.DataAnnotations;

namespace Pedidos.Models.DTO;
public class CrearPedido
{
    public int IdUsuario { get; set; }
    public DateTime FechaPedido { get; set; }
    public string Estado { get; set; }
    public decimal Total { get; set; }
    public string DireccionHasta { get; set; }
    public string DireccionDesde { get; set; }

    // Lista de productos que lleva el pedido
    public List<CrearPedidoProducto> PedidoProductos { get; set; }
}
