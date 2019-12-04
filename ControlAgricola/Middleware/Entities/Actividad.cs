using System;
using System.Collections.Generic;

namespace ControlAgricola.Middleware.Entities
{
    public partial class Actividad
    {
        public int IdActividad { get; set; }
        public decimal Cantidad { get; set; }
        public string MetodoAplicacion { get; set; }
        public string Meteorologia { get; set; }
        public string Foto { get; set; }
        public DateTime Fecha { get; set; }
        public int IdLote { get; set; }
        public int IdUsuario { get; set; }
        public int IdTipoActividad { get; set; }
        public int IdProducto { get; set; }
        public int IdPermiso { get; set; }

        public virtual Lote IdLoteNavigation { get; set; }
        public virtual Permiso IdPermisoNavigation { get; set; }
        public virtual ProductoPermitido IdProductoNavigation { get; set; }
        public virtual TipoActividad IdTipoActividadNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
