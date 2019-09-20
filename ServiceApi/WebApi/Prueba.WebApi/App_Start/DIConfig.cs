using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApi.DataLayer.Abstracts;
using WebApi.DataLayer.Implements;
using WebApi.DataLayer.MongoSettings;

namespace Cibertec.WebApi.App_Start
{
    public class DIConfig
    {
        public static void ConfigureInjector(HttpConfiguration config)
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.Register<IUnitOfWork>(() => new UnitOfWork(new Settings()
            {
                ConnectionString = ConfigurationManager.AppSettings["MongoDB.ConnectionString"],
                Database = ConfigurationManager.AppSettings["MongoDB.DataBase"]
            }));


            //container.Register<IClientesService, ClientesService>();
       

            container.Verify();
            config.DependencyResolver = new SimpleInjector.Integration.WebApi.SimpleInjectorWebApiDependencyResolver(container);
        }
    }

}