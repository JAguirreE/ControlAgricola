using System;
using System.Collections.Generic;

namespace ControlAgricola.Middleware.Entities
{
    public partial class Permiso
    {
        public Permiso()
        {
            Actividad = new HashSet<Actividad>();
        }

        public int IdPermiso { get; set; }
        public string Numero { get; set; }
        public int IdCategoria { get; set; }

        public virtual CategoriaProducto IdCategoriaNavigation { get; set; }
        public virtual ICollection<Actividad> Actividad { get; set; }
    }
}
