using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PruebaTec02KDSB.Models
{
    public partial class Medida
    {
        public Medida()
        {
            Ceramicas = new HashSet<Ceramica>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name ="Tamaño")]
        public string Medida1 { get; set; } = null!;

        public virtual ICollection<Ceramica> Ceramicas { get; set; }
    }
}
