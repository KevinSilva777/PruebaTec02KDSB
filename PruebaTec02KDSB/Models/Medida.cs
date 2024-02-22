using System;
using System.Collections.Generic;

namespace PruebaTec02KDSB.Models
{
    public partial class Medida
    {
        public Medida()
        {
            Ceramicas = new HashSet<Ceramica>();
        }

        public int Id { get; set; }
        public string Medida1 { get; set; } = null!;

        public virtual ICollection<Ceramica> Ceramicas { get; set; }
    }
}
