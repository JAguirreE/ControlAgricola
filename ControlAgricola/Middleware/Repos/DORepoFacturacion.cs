using ControlAgricola.Middleware.Contracts;
using ControlAgricola.Middleware.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlAgricola.Middleware.Repos
{
  public class DORepoFacturacion
  {
    public DORepoFacturacion()
    {

    }

    /// <summary>
    /// Registra en BD el encabezado de la factura
    /// </summary>
    /// <param name="factura">Entidad de la factura con los datos</param>
    public void RegistrarFactura(Factura factura)
    {
      using(controlagricolaContext context = new controlagricolaContext())
      {
        Factura facturaEntidad = context.Factura.Find(factura.IdFac);

        if(facturaEntidad != null)
        {
          MapearFacturaEntidad(factura, facturaEntidad);
        } 
        else
        {
          context.Factura.Add(factura);
        }
        context.SaveChanges();
      }
    }

    public void MapearFacturaEntidad(Factura entidadOrigen, Factura entidadDestino)
    {
      entidadDestino.Numero = entidadOrigen.Numero;
      entidadDestino.Fecha = entidadOrigen.Fecha;
      entidadDestino.Fecha = entidadOrigen.Fecha;
      entidadDestino.Receptor = entidadOrigen.Receptor;
      entidadDestino.ValorBase = entidadOrigen.ValorBase;
      entidadDestino.ValorImpuestos = entidadOrigen.ValorImpuestos;
      entidadDestino.ValorTotal = entidadOrigen.ValorTotal;
      entidadDestino.Estado = entidadOrigen.Estado;
    }

    /// <summary>
    /// Registra los detalles de la factura
    /// </summary>
    /// <param name="detalle">Entidad con los datos</param>
    public void RegistarFacturaDetalle(FacturaDetalle detalle)
    {
      using (controlagricolaContext context = new controlagricolaContext())
      {
        FacturaDetalle detalleEntidad = context.FacturaDetalle.Find(detalle.IdDetFac);

        if (detalleEntidad != null)
        {
          MapearDetalleEntidad(detalle, detalleEntidad);
        }
        else
        {
          context.FacturaDetalle.Add(detalle);
        }

        context.SaveChanges();
      }
    }

    public void MapearDetalleEntidad(FacturaDetalle entidadOrigen, FacturaDetalle entidadDestino)
    {
      entidadDestino.Concepto = entidadOrigen.Concepto;
      entidadDestino.Cantidad = entidadOrigen.Cantidad;
      entidadDestino.ValorUnidad = entidadOrigen.ValorUnidad;
      entidadDestino.Subtotal = entidadOrigen.Subtotal;
      entidadDestino.Estado = entidadOrigen.Estado;
    }

    /// <summary>
    /// Marca como "Cancelado" un registro de factura
    /// </summary>
    /// <param name="idFactura">ID de la factura</param>
    public void DeleteFactura(long idFactura)
    {
      using (controlagricolaContext context = new controlagricolaContext())
      {
        Factura facturaEntidad = context.Factura.Find(idFactura);
        facturaEntidad.Estado = "CAN";
        context.SaveChanges();
      }
    }

    /// <summary>
    /// Marca como "Cancelado" el detalle de una factura
    /// </summary>
    /// <param name="idFacturaDetalle"></param>
    public void DeleteFacturaDetalle(long idFacturaDetalle)
    {
      using (controlagricolaContext context = new controlagricolaContext())
      {
        FacturaDetalle detalleEntidad = context.FacturaDetalle.Find(idFacturaDetalle);
        detalleEntidad.Estado = "CAN";
        context.SaveChanges();
      }
    }

    /// <summary>
    /// Obtiene los datos registrados de una factura
    /// </summary>
    /// <param name="idFactura">ID de la factura</param>
    /// <returns></returns>
    public Factura GetFactura(long idFactura)
    {
      using (controlagricolaContext context = new controlagricolaContext())
      {
        Factura facturaEntidad = context.Factura.Find(idFactura);
        return facturaEntidad;
      }
    }

    /// <summary>
    /// Obtiene todas las cabeceras de facturas vigentes
    /// </summary>
    /// <returns>Listado de entidades de factura</returns>
    public IEnumerable<Factura> GetFacturas()
    {
      using(controlagricolaContext context = new controlagricolaContext())
      {
        IEnumerable<Factura> facturasEntidades = context.Factura
          .Where(w => w.Estado == "VIG")
          .ToList();

        return facturasEntidades;
      }
    }

    /// <summary>
    /// Obtiene los datos registrados de un detalle de factura
    /// </summary>
    /// <param name="idFacturaDetalle">ID del detalle</param>
    /// <returns></returns>
    public FacturaDetalle GetFacturaDetalle(long idFacturaDetalle)
    {
      using (controlagricolaContext context = new controlagricolaContext())
      {
        FacturaDetalle facturaDetalleEntidad = context.FacturaDetalle.Find(idFacturaDetalle);
        return facturaDetalleEntidad;
      }
    }

    /// <summary>
    /// Obtiene todos los detalles registrados de una factura
    /// </summary>
    /// <param name="idFac"></param>
    /// <returns></returns>
    public IEnumerable<FacturaDetalle> GetFacturaDetalleAll(long idFac)
    {
      using (controlagricolaContext context = new controlagricolaContext())
      {
        IEnumerable<FacturaDetalle> detallesEntidad = context.FacturaDetalle
          .Where(w => w.IdFac == idFac && w.Estado == "VIG")
          .ToList();

        return detallesEntidad;
      }
    }
  }
}
