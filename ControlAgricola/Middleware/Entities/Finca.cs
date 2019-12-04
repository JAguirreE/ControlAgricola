using System;
using System.Collections.Generic;

namespace ControlAgricola.Middleware.Entities
{
    public partial class Finca
    {
        public Finca()
        {
            Lote = new HashSet<Lote>();
        }

        public int IdFinca { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Tamano { get; set; }

        public virtual ICollection<Lote> Lote { get; set; }
    }
}
