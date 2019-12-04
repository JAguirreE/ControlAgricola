using System;
using System.Collections.Generic;

namespace ControlAgricola.Middleware.Entities
{
    public partial class Lote
    {
        public Lote()
        {
            Actividad = new HashSet<Actividad>();
        }

        public int IdLote { get; set; }
        public string Nombre { get; set; }
        public string Tamano { get; set; }
        public int IdFinca { get; set; }

        public virtual Finca IdFincaNavigation { get; set; }
        public virtual ICollection<Actividad> Actividad { get; set; }
    }
}
