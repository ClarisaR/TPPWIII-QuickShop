using Microsoft.EntityFrameworkCore;
using Productos.Models;

namespace Productos.Data
{
    public class ProductoDbContext : DbContext
    {
        public ProductoDbContext(DbContextOptions<ProductoDbContext> options)
            : base(options)
        {
        }

        // DbSet por cada entidad
        public DbSet<Local> Locales { get; set; }
        public DbSet<Rubro> Rubros { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Variante> Variantes { get; set; }
        public DbSet<Color> Colores { get; set; }
        public DbSet<Talle> Talles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.CategoriaId);

            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Local)
                .WithMany(l => l.Productos)
                .HasForeignKey(p => p.LocalId);

            modelBuilder.Entity<Local>()
                .HasOne(l => l.Rubro)
                .WithMany()
                .HasForeignKey(l => l.RubroId);
        }
    }
}
