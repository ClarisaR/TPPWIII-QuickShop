﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Productos.Models
{
    public class Variante
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Producto")]
        public int ProductoId { get; set; }
        public Producto Producto { get; set; } = null!;

        [ForeignKey("Color")]
        public int ColorId { get; set; }
        public Color Color { get; set; } = null!;

        [ForeignKey("Talle")]
        public int TalleId { get; set; }
        public Talle Talle { get; set; } = null!;

        public int Stock { get; set; }

    }
}
