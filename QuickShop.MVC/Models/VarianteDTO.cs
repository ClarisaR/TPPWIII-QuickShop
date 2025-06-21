using System.Drawing;
using Microsoft.AspNetCore.Components.Forms;

namespace QuickShop.MVC.Models
{
    public class VarianteDTO
    {
        public int Id { get; set; }

        public int ProductoId { get; set; }

        public ProductoDTO? Producto { get; set;}

        public int? ColorId { get; set; }

        public ColorDTO? Color { get; set; }

        public int? TalleId { get; set; }

        public TalleDTO? Talle { get; set; }

        public int? Stock { get; set; }

    }
}