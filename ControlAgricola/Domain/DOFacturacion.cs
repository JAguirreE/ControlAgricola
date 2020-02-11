using ControlAgricola.Middleware.Contracts;
using ControlAgricola.Middleware.Entities;
using ControlAgricola.Middleware.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlAgricola.Domain
{
  public class DOFacturacion
  {
    private DORepoFacturacion repoFacturacion;

    public DOFacturacion()
    {
      repoFacturacion = new DORepoFacturacion();
    }

    public LiquidacionDatos RegistrarFactura(FacturaDatos factura)
    {
      LiquidacionDatos liquidacion = Liquidar(factura);

      factura.Estado = "VIG";
      repoFacturacion.RegistrarFactura(factura);

      foreach (FacturaDetalle detalle in factura.Detalles)
      {
        detalle.Estado = "VIG";
        detalle.IdFac = factura.IdFac;
        repoFacturacion.RegistarFacturaDetalle(detalle);
      }
      liquidacion.idFac = factura.IdFac;
      return liquidacion;
    }

    public void RegistrarFacturaDetalle(FacturaDetalle detalle)
    {
      detalle.Estado = "VIG";
      repoFacturacion.RegistarFacturaDetalle(detalle);
    }

    internal LiquidacionDatos Liquidar(FacturaDatos factura)
    {
      decimal valorBase = 0;
      foreach (FacturaDetalle detalle in factura.Detalles)
      {
        detalle.Subtotal = detalle.Cantidad * detalle.ValorUnidad;
        valorBase += detalle.Subtotal;
        detalle.Estado = "VIG";
      }

      factura.ValorBase = valorBase;
      factura.ValorImpuestos = valorBase * (decimal)0.2;
      factura.ValorTotal = factura.ValorBase + factura.ValorImpuestos;

      LiquidacionDatos liquidacion = new LiquidacionDatos
      {
        ValorBase = factura.ValorBase,
        ValorImpuestos = factura.ValorImpuestos,
        ValorTotal = factura.ValorTotal
      };

      return liquidacion;
    }

    public void DeleteFactura(long idFactura)
    {
      repoFacturacion.DeleteFactura(idFactura);
    }

    /// <summary>
    /// Marca como "Cancelado" la cabecera de la factura y todos sus detalles
    /// </summary>
    /// <param name="idFactura">ID de la factura</param>
    public void DeleteFacturaAll(long idFactura)
    {
      repoFacturacion.DeleteFactura(idFactura);
      IEnumerable<FacturaDetalle> detallesEntidad = repoFacturacion.GetFacturaDetalleAll(idFactura);

      foreach(FacturaDetalle detalle in detallesEntidad)
      {
        repoFacturacion.DeleteFacturaDetalle(detalle.IdDetFac);
      }
    }

    public void DeleteFacturaDetalle(long idFacturaDetalle)
    {
      repoFacturacion.DeleteFacturaDetalle(idFacturaDetalle);
    }

    public Factura GetFactura(long idFactura)
    {
      return repoFacturacion.GetFactura(idFactura);
    }

    public IEnumerable<Factura> GetFacturas()
    {
      return repoFacturacion.GetFacturas();
    }

    public FacturaDetalle GetFacturaDetalle(long idFacturaDetalle)
    {
      return repoFacturacion.GetFacturaDetalle(idFacturaDetalle);
    }

    public IEnumerable<FacturaDetalle> GetFacturaDetalleAll(long idFactura)
    {
      return repoFacturacion.GetFacturaDetalleAll(idFactura);
    }
  }
}
