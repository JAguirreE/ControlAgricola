using ControlAgricola.Middleware;
using ControlAgricola.Middleware.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlAgricola.Domain
{
  public class DOActividades : controlagricolaContext
  {
    public List<TipoActividad> GetTiposActividad()
    {
      using(controlagricolaContext context = new controlagricolaContext())
      {
        List<TipoActividad> tiposActividad = context.TipoActividad.ToList();

        return tiposActividad;
      }
    }
  }
}
