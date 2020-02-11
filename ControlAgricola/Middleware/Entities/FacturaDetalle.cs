using System;
using System.Collections.Generic;

namespace ControlAgricola.Middleware.Entities
{
    public partial class FacturaDetalle
    {
        public long IdDetFac { get; set; }
        public long IdFac { get; set; }
        public string Concepto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal ValorUnidad { get; set; }
        public decimal Subtotal { get; set; }
        public string Estado { get; set; }

        public virtual Factura IdFacNavigation { get; set; }
    }
}
