using ControlAgricola.Middleware;
using ControlAgricola.Middleware.Contracts;
using ControlAgricola.Middleware.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlAgricola.Domain
{
  public class DOActividades : controlagricolaContext
  {
    public void RegistrarActividad(Actividad actividad)
    {
      using (controlagricolaContext context = new controlagricolaContext())
      {
        context.Actividad.Add(actividad);
        context.SaveChanges();
      }
    }

    public List<TipoActividad> GetTiposActividad()
    {
      using (controlagricolaContext context = new controlagricolaContext())
      {
        List<TipoActividad> tiposActividad = context.TipoActividad.ToList();

        return tiposActividad;
      }
    }

    public List<ProductoPermitido> GetProductos()
    {
      using (controlagricolaContext context = new controlagricolaContext())
      {
        List<ProductoPermitido> productos = context.ProductoPermitido.ToList();

        return productos;
      }
    }

    public List<ProductoPermitido> GetProductosActividad(int idTipo)
    {
      using (controlagricolaContext context = new controlagricolaContext())
      {
        List<ProductoPermitido> productos = context.ProductoPermitido
          .Where(w => w.IdCategoria == idTipo)
          .ToList();

        return productos;
      }
    }

    public List<Permiso> GetPermisos()
    {
      using (controlagricolaContext context = new controlagricolaContext())
      {
        List<Permiso> permisos = context.Permiso.ToList();

        return permisos;
      }
    }

    public List<ActividadDatos> GetActividades()
    {
      using (controlagricolaContext context = new controlagricolaContext())
      {
        List<ActividadDatos> actividades =
          (
            from act in context.Actividad
            join lot in context.Lote
              on act.IdLote equals lot.IdLote
            join fin in context.Finca
              on lot.IdFinca equals fin.IdFinca
            join tip in context.TipoActividad
              on act.IdTipoActividad equals tip.IdTipo
            join pro in context.ProductoPermitido
              on act.IdProducto equals pro.IdProducto
            join usu in context.Usuario
              on act.IdUsuario equals usu.IdUsuario
            select new ActividadDatos
            {
              IdActividad = act.IdActividad,
              Cantidad = act.Cantidad,
              MetodoAplicacion = act.MetodoAplicacion,
              Meteorologia = act.Meteorologia,
              Fecha = act.Fecha,
              NombreLote = lot.Nombre,
              NombreFinca = fin.Nombre,
              NombreUsuario = usu.Nombre,
              NombreProducto = pro.Nombre,
              NombreTipoActividad = tip.Nombre,
              IdLote = act.IdLote,
              IdTipoActividad = act.IdTipoActividad
            }
          )
          .OrderBy(o => o.IdLote)
          .ThenBy(t => t.Fecha)
          .ToList();

        return actividades;
      }
    }

    public List<ActividadDatos> GetActividadesCosecha(int idLote)
    {
      using (controlagricolaContext context = new controlagricolaContext())
      {
        List<ActividadDatos> actividades =
          (
            from act in context.Actividad
            join lot in context.Lote
              on act.IdLote equals lot.IdLote
            join fin in context.Finca
              on lot.IdFinca equals fin.IdFinca
            join tip in context.TipoActividad
              on act.IdTipoActividad equals tip.IdTipo
            join pro in context.ProductoPermitido
              on act.IdProducto equals pro.IdProducto
            join usu in context.Usuario
              on act.IdUsuario equals usu.IdUsuario
            where act.IdLote == idLote
            select new ActividadDatos
            {
              IdActividad = act.IdActividad,
              Cantidad = act.Cantidad,
              MetodoAplicacion = act.MetodoAplicacion,
              Meteorologia = act.Meteorologia,
              Fecha = act.Fecha,
              NombreLote = lot.Nombre,
              NombreFinca = fin.Nombre,
              NombreUsuario = usu.Nombre,
              NombreProducto = pro.Nombre,
              NombreTipoActividad = tip.Nombre,
              IdLote = act.IdLote,
              IdTipoActividad = act.IdTipoActividad
            }
          )
          .OrderBy(o => o.IdLote)
          .ThenBy(t => t.Fecha)
          .ToList();

        return actividades;
      }
    }
  }
}
