using System;
using System.Collections.Generic;

namespace ControlAgricola.Middleware.Entities
{
    public partial class TipoActividad
    {
        public TipoActividad()
        {
            Actividad = new HashSet<Actividad>();
        }

        public int IdTipo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Actividad> Actividad { get; set; }
    }
}
