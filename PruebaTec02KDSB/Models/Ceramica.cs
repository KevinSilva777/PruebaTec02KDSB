using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PruebaTec02KDSB.Models
{
    public partial class Ceramica
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Solo se permiten letras.")]
        public string Nombre { get; set; } = null!;
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Solo se permiten letras.")]
        public string? Tipo { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Solo se permiten números.")]
        public decimal? Precio { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Solo se permiten letras.")]
        public string? Color { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public byte[]? Imagen { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Tamaño")]
        public int? TamañoId { get; set; }

        public virtual Medida? Tamaño { get; set; }
    }
}
