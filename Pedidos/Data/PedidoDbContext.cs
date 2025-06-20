using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Pedidos.Models;

namespace Pedidos.Data
{
    public class PedidoDbContext : DbContext
    {
        public PedidoDbContext(DbContextOptions<PedidoDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PedidoProducto>()
                .HasKey(pp => new { pp.IdPedido, pp.IdProducto });
        }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoProducto> PedidoProductos{ get; set; }
    }
}
