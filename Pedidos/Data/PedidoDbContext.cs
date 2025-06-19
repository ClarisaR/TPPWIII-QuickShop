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
            // Configuración de la relación entre Pedido y PedidoProducto
            modelBuilder.Entity<PedidoProducto>()
                .HasKey(pp => new { pp.IdPedido, pp.IdProducto });
            modelBuilder.Entity<PedidoProducto>()
                .HasOne(pp => pp.Pedido)
                .WithMany(p => p.PedidoProductos)
                .HasForeignKey(pp => pp.IdPedido);
        }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoProducto> PedidoProductos{ get; set; }
    }
}
