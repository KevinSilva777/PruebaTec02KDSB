using System;
using System.Collections.Generic;

namespace PruebaTec02KDSB.Models
{
    public partial class Tamaño
    {
        public Tamaño()
        {
            Seramicas = new HashSet<Seramica>();
        }

        public int Id { get; set; }
        public string Medida { get; set; } = null!;

        public virtual ICollection<Seramica> Seramicas { get; set; }
    }
}
