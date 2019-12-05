using ControlAgricola.Middleware.Contracts;
using ControlAgricola.Middleware.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlAgricola.Domain
{
  public class DOLote
  {

    public void RegistrarLote(Lote lote)
    {
      using (controlagricolaContext context = new controlagricolaContext())
      {
        context.Lote.Add(lote);
        context.SaveChanges();
      }
    }

    public List<Lote> GetLotes()
    {
      using (controlagricolaContext context = new controlagricolaContext())
      {
        return context.Lote.ToList();
      }
    }

    public List<LoteDatos> GetLotesDatos()
    {
      using (controlagricolaContext context = new controlagricolaContext())
      {
        List<LoteDatos> lotesDatos = 
          (
            from lot in context.Lote
            join fin in context.Finca 
              on lot.IdFinca equals fin.IdFinca
            select new LoteDatos
            {
              IdLote = lot.IdLote,
              Nombre = lot.Nombre,
              Tamano = lot.Tamano,
              IdFinca = lot.IdFinca,
              Finca = fin.Nombre,
            }
          )
          .OrderBy(o => o.IdFinca)
          .ToList();

        return lotesDatos;
      }
    }
  }
}
