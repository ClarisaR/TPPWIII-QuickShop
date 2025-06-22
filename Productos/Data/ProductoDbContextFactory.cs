using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Productos.Data
{
    public class ProductoDbContextFactory : IDesignTimeDbContextFactory<ProductoDbContext>
    {
        public ProductoDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProductoDbContext>();
            optionsBuilder.UseSqlServer("Server=productos-db;Database=ProductosDB;User=sa;Password=productos123!;TrustServerCertificate=True");

            return new ProductoDbContext(optionsBuilder.Options);
        }
    }
}
