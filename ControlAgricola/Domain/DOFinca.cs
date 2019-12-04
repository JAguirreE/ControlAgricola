using ControlAgricola.Middleware.Contracts;
using ControlAgricola.Middleware.Entities;

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
  }
}
