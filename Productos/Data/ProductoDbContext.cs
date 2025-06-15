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

            // Producto -> Categoria (muchos a uno)
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.CategoriaId);

            // Producto -> Local (muchos a uno)
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Local)
                .WithMany(l => l.Productos)
                .HasForeignKey(p => p.LocalId);

            // Local -> Rubro (muchos a uno)
            modelBuilder.Entity<Local>()
                .HasOne(l => l.Rubro)
                .WithMany(r => r.Locales)
                .HasForeignKey(l => l.RubroId);

            // Variante -> Producto (muchos a uno)
            modelBuilder.Entity<Variante>()
                .HasOne(v => v.Producto)
                .WithMany(p => p.Variantes)
                .HasForeignKey(v => v.ProductoId);

            // Variante -> Talle (muchos a uno)
            modelBuilder.Entity<Variante>()
                .HasOne(v => v.Talle)
                .WithMany(t => t.Variantes)
                .HasForeignKey(v => v.TalleId);

            // Variante -> Color (muchos a uno)
            modelBuilder.Entity<Variante>()
                .HasOne(v => v.Color)
                .WithMany(c => c.Variantes)
                .HasForeignKey(v => v.ColorId);

            // Local -> Direccion (muchos a uno)
            modelBuilder.Entity<Local>()
                .HasOne(l => l.Direccion)
                .WithOne() // Relacion unidireccional uno a uno
                .HasForeignKey<Local>(l => l.DireccionId);
        }
    }
}
