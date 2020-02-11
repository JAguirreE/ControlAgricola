using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlAgricola.Middleware.Contracts
{
  public class LiquidacionDatos
  {
    public decimal ValorBase { get; set; }
    public decimal ValorImpuestos { get; set; }
    public decimal ValorTotal { get; set; }
    public long idFac { get; set; }
  }
}
