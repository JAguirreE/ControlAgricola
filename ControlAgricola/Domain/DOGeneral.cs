using ControlAgricola.Middleware.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlAgricola.Domain
{
  public class DOGeneral
  {
    public void RegistrarUsuario(Usuario usuario)
    {
      using (controlagricolaContext context = new controlagricolaContext())
      {
        context.Usuario.Add(usuario);
        context.SaveChanges();
      }
    }

    public List<Usuario> GetUsuarios()
    {
      using (controlagricolaContext context = new controlagricolaContext())
      {
        return context.Usuario.ToList();
      }
    }

    public List<Rol> GetRoles()
    {
      using (controlagricolaContext context = new controlagricolaContext())
      {
        return context.Rol.ToList();
      }
    }
  }
}
