using System;
using System.Collections.Generic;

namespace PruebaTec02KDSB.Models
{
    public partial class Ceramica
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Tipo { get; set; }
        public decimal? Precio { get; set; }
        public string? Color { get; set; }
        public byte[]? Imagen { get; set; }
        public int? TamañoId { get; set; }

        public virtual Medida? Tamaño { get; set; }
    }
}
