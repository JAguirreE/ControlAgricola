using System;
using System.Collections.Generic;

namespace ControlAgricola.Middleware.Entities
{
    public partial class ProductoPermitido
    {
        public ProductoPermitido()
        {
            Actividad = new HashSet<Actividad>();
        }

        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public int IdCategoria { get; set; }

        public virtual CategoriaProducto IdCategoriaNavigation { get; set; }
        public virtual ICollection<Actividad> Actividad { get; set; }
    }
}
