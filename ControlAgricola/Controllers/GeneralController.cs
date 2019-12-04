using ControlAgricola.Domain;
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
    private readonly DOActividades doactividades;

    public GeneralController()
    {
      dofinca = new DOFinca();
      doactividades = new DOActividades();
    }

    [Route("RegistrarFinca")]
    [HttpPost]
    public void RegistrarFinca(Finca finca)
    {
      dofinca.RegistrarFinca(finca);
    }

    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    [Route("GetTiposActividad")]
    [HttpGet]
    public List<TipoActividad> GetTiposActividad()
    {
      return doactividades.GetTiposActividad();
    }

  }
}
