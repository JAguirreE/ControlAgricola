using System;
using System.Collections.Generic;

namespace ControlAgricola.Middleware.Entities
{
    public partial class Factura
    {
        public Factura()
        {
            FacturaDetalle = new HashSet<FacturaDetalle>();
        }

        public long IdFac { get; set; }
        public string Numero { get; set; }
        public DateTime Fecha { get; set; }
        public string Emisor { get; set; }
        public string Receptor { get; set; }
        public decimal ValorBase { get; set; }
        public decimal ValorImpuestos { get; set; }
        public decimal ValorTotal { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<FacturaDetalle> FacturaDetalle { get; set; }
    }
}
