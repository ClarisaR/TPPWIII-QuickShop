﻿using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pedidos.Data;
using Pedidos.Models;
using Pedidos.Models.DTO;

namespace Pedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly PedidoDbContext _context;

        public PedidosController(PedidoDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostPedido([FromBody] CrearPedido pedidoDTO)
        {

            var total = pedidoDTO.PedidoProductos.Sum(pp => pp.CantidadProductos * pp.PrecioUnitario);
            var pedido = new Pedido
            {
                IdUsuario = pedidoDTO.IdUsuario,
                FechaPedido = DateTime.UtcNow,
                Estado = pedidoDTO.Estado,
                Total = total,
                DireccionHasta = pedidoDTO.DireccionHasta,
                DireccionDesde = pedidoDTO.DireccionDesde,
                PedidoProductos = new List<PedidoProducto>() // Inicializamos
            };

            // Primero guardamos el pedido para que tenga IdPedido
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            // Ahora agregamos los productos con el IdPedido ya generado
            foreach (var pp in pedidoDTO.PedidoProductos)
            {
                var pedidoProducto = new PedidoProducto
                {
                    IdPedido = pedido.IdPedido, // Se asigna el ID generado
                    IdProducto = pp.IdProducto,
                    CantidadProductos = pp.CantidadProductos,
                    PrecioUnitario = pp.PrecioUnitario
                };
                _context.PedidoProductos.Add(pedidoProducto);
            }

            await _context.SaveChangesAsync();

            return Ok(new { id = pedido.IdPedido });
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return pedido;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos()
        {
            return await _context.Pedidos.ToListAsync();
        }

        [HttpGet("usuario/{idUsuario}")]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidosPorUsuario(int idUsuario)
        {
            var pedidos = await _context.Pedidos
                .Where(p => p.IdUsuario == idUsuario)
                .ToListAsync();
            if (pedidos == null || !pedidos.Any())
            {
                return NotFound($"No se encontraron pedidos para el usuario con ID {idUsuario}.");
            }
            return pedidos;
        }

        [HttpGet("detalles/{id}")]
        public async Task<ActionResult<IEnumerable<PedidoProducto>>> GetDetallesPedido(int id)
        {
            var detalles = await _context.PedidoProductos
                .Where(pp => pp.IdPedido == id)
                .ToListAsync();
            if (detalles == null || !detalles.Any())
            {
                return NotFound($"No se encontraron detalles para el pedido con ID {id}.");
            }
            return detalles;
        }
    }
}
