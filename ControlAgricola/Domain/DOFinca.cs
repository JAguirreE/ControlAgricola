using ControlAgricola.Middleware.Contracts;
using ControlAgricola.Middleware.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ControlAgricola.Domain
{
  public class DOFinca
  {
    public void RegistrarFinca(Finca finca)
    {
      using (controlagricolaContext context = new controlagricolaContext())
      {
        context.Finca.Add(finca);
        context.SaveChanges();
      }
    }

    public List<Finca> GetFincas()
    {
      using (controlagricolaContext context = new controlagricolaContext())
      {
        return context.Finca.ToList();
      }
    }
  }
}
