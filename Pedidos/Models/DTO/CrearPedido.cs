using System.ComponentModel.DataAnnotations;

namespace Pedidos.Models.DTO;
public class CrearPedido
{
    public int IdUsuario { get; set; }
    public string Estado { get; set; }
    public string DireccionHasta { get; set; }
    public string DireccionDesde { get; set; }
    public List<CrearPedidoProducto> PedidoProductos { get; set; }
}
