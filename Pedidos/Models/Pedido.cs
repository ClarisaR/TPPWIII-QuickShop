using System.ComponentModel.DataAnnotations;

namespace Pedidos.Models;

public class Pedido
{
    [Key]
    public int IdPedido { get; set; }

    [Required]
    public int IdUsuario { get; set; }

    [Required]
    public DateTime FechaPedido { get; set; }

    [Required]
    [MaxLength(20)]
    public string Estado { get; set; } // Ejemplo: "Pendiente", "Enviado", "Entregado"

    [Range(0, double.MaxValue)]
    public decimal Total { get; set; } // Monto total del pedido

    [Required]
    [MaxLength(255)]
    public string DireccionHasta { get; set; } // Dirección de entrega

    [Required]
    [MaxLength(255)]
    public string DireccionDesde { get; set; } // Dirección de envío

    // Relación con productos: lista de PedidoProducto
    public List<PedidoProducto> PedidoProductos { get; set; } = new List<PedidoProducto>();
}
