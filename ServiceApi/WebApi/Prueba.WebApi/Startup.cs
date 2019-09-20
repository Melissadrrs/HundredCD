using System;
//using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;
using Cibertec.WebApi.App_Start;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Owin;
using WebApi.App_Start;
using WebApi.DataLayer.Abstracts;
using WebApi.DataLayer.Implements;
using WebApi.DataLayer.MongoSettings;


[assembly: OwinStartup(typeof(WebApi.Startup))]

namespace WebApi
{
    public class Startup
    {


        public void Configuration(IAppBuilder app)
        {

            var config = new HttpConfiguration();
            DIConfig.ConfigureInjector(config);
            RouteConfig.Register(config);
            TokenConfig.ConfigureOAuth(app, config);
            WebApiConfig.Register(config);
            app.UseWebApi(config);


        }

    }
    }
