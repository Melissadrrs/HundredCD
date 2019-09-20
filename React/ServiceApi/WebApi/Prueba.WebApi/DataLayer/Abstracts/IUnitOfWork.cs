using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace WebApi.DataLayer.Abstracts
{
    public interface IUnitOfWork
    {
         IClientesService Clientes { get; }
         IUsuariosService Usuarios { get; }
    }
}