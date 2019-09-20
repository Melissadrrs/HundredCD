using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using System.Threading.Tasks;
using WebApi.DataLayer.Abstracts;

namespace WebApi.App_Start
{
    public class TokenConfig
    {
        public static void ConfigureOAuth(IAppBuilder app ,HttpConfiguration config)
        {
            var unitOfWork = (IUnitOfWork)config.DependencyResolver.GetService(typeof(IUnitOfWork));
            OAuthAuthorizationServerOptions oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new Microsoft.Owin.PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider(unitOfWork)
            };

            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }
    }

    public class SimpleAuthorizationServerProvider: OAuthAuthorizationServerProvider
    {
        private readonly IUnitOfWork _unit;

        public SimpleAuthorizationServerProvider(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            await Task.Factory.StartNew(() => { context.Validated(); });
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            await Task.Factory.StartNew(() =>
            {
                bool rpta=  _unit.Usuarios.ValidateUsuario(context.UserName, context.Password);
                if (!rpta)
                {
                    context.SetError("invalid_grat", "Usuario o clave incorrecta");
                    return;
                }

                var identity = new System.Security.Claims.ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new System.Security.Claims.Claim("sub", context.UserName));
                identity.AddClaim(new System.Security.Claims.Claim("role", "user"));

                context.Validated(identity);

            });
        }
    }
}