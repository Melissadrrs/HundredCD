using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.DataLayer.Abstracts;
using WebApi.DataLayer.MongoSettings;

namespace WebApi.DataLayer.Implements
{
    public class UnitOfWork:IUnitOfWork
    {
        public UnitOfWork(Settings settings)
        {
            Clientes = new ClientesService(settings);
            Usuarios = new UsuariosService(settings);

        }

        public IClientesService Clientes { get; private set; }
        public IUsuariosService Usuarios { get; private set; }

    }
}