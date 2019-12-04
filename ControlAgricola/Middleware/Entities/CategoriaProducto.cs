using System;
using System.Collections.Generic;

namespace ControlAgricola.Middleware.Entities
{
    public partial class CategoriaProducto
    {
        public CategoriaProducto()
        {
            Permiso = new HashSet<Permiso>();
            ProductoPermitido = new HashSet<ProductoPermitido>();
        }

        public int IdCategoria { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Permiso> Permiso { get; set; }
        public virtual ICollection<ProductoPermitido> ProductoPermitido { get; set; }
    }
}
