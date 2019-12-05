﻿using ControlAgricola.Domain;
using ControlAgricola.Middleware.Contracts;
using ControlAgricola.Middleware.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ControlAgricola.Controllers
{
  [DisableCors]
  [Route("api/[controller]")]
  [ApiController]
  public class GeneralController : ControllerBase
  {
    private readonly DOFinca dofinca;
    private readonly DOLote dolote;
    private readonly DOActividades doactividades;
    private readonly DOGeneral dogeneral;

    public GeneralController()
    {
      dofinca = new DOFinca();
      doactividades = new DOActividades();
      dolote = new DOLote();
      dogeneral = new DOGeneral();
    }

    #region Finca
    [Route("RegistrarFinca")]
    [HttpPost]
    public void RegistrarFinca(Finca finca)
    {
      dofinca.RegistrarFinca(finca);
    }

    [Route("GetFincas")]
    [HttpGet]
    public List<Finca> GetFincas()
    {
      return dofinca.GetFincas();
    }
    #endregion

    #region Lote
    [Route("RegistrarLote")]
    [HttpPost]
    public void RegistrarLote(Lote lote)
    {
      dolote.RegistrarLote(lote);
    }

    [Route("GetLotes")]
    [HttpGet]
    public List<Lote> GetLotes()
    {
      return dolote.GetLotes();
    }

    [Route("GetLotesDatos")]
    [HttpGet]
    public List<LoteDatos> GetLotesDatos()
    {
      return dolote.GetLotesDatos();
    }
    #endregion

    #region General
    [Route("RegistrarUsuario")]
    [HttpPost]
    public void RegistrarUsuario(Usuario usuario)
    {
      dogeneral.RegistrarUsuario(usuario);
    }

    [Route("GetRoles")]
    [HttpGet]
    public List<Rol> GetRoles()
    {
      return dogeneral.GetRoles();
    }

    [Route("GetUsuarios")]
    [HttpGet]
    public List<Usuario> GetUsuarios()
    {
      return dogeneral.GetUsuarios();
    }
    #endregion

    #region Actividad
    [Route("RegistrarActividad")]
    [HttpPost]
    public void RegistrarActividad(Actividad actividad)
    {
      doactividades.RegistrarActividad(actividad);
    }

    [Route("GetTiposActividad")]
    [HttpGet]
    public List<TipoActividad> GetTiposActividad()
    {
      return doactividades.GetTiposActividad();
    }

    [Route("GetProductos")]
    [HttpGet]
    public List<ProductoPermitido> GetProductos()
    {
      return doactividades.GetProductos();
    }

    [Route("GetProductosActividad")]
    [HttpGet]
    public List<ProductoPermitido> GetProductosActividad(int idTipo)
    {
      return doactividades.GetProductosActividad(idTipo);
    }

    [Route("GetActividades")]
    [HttpGet]
    public List<ActividadDatos> GetActividades()
    {
      return doactividades.GetActividades();
    }


    #endregion

  }
}
