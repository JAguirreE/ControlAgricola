using ControlAgricola.Middleware.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlAgricola.Middleware.Contracts
{
  public class FacturaDatos : Factura
  {
    public IEnumerable<FacturaDetalle> Detalles { get; set; }
  }
}
