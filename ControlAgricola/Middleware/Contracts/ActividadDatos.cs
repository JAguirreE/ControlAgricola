using ControlAgricola.Middleware.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlAgricola.Middleware.Contracts
{
  public class ActividadDatos : Actividad
  {
    public string NombreTipoActividad { get; set; }
    public string NombreFinca { get; set; }
    public string NombreLote { get; set; }
    public string NombreProducto { get; set; }
    public string NombreUsuario { get; set; }

  }
}
