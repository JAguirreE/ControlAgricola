using ControlAgricola.Middleware.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlAgricola.Middleware.Contracts
{
  public class LoteDatos : Lote
  {
    public string Finca { get; set; }
  }
}
