using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi.DataLayer.Abstracts;

namespace WebApi.Controllers
{
    [RoutePrefix("user")]
    public class UsuarioController : BaseController
    {
        public UsuarioController(IUnitOfWork unit) : base(unit)
        {

        }
   

        [HttpGet]
        [Route("get")]
        public Task<IEnumerable<Models.Usuarios>> Get()
        {
            return _unit.Usuarios.GetAllUsuarios();
        }

        //[AllowAnonymous]
        //[Route("insert")]
        //[HttpPost]
        //public IHttpActionResult Insert(
        //    [FromBody]Models.Usuarios usuario)
        //{
        //    if (!ModelState.IsValid) return BadRequest(ModelState);
        //    _unit.Usuarios.InsertUsuario(usuario);
        //    return Ok();
        //}



        [AllowAnonymous]
        [Route("insert")]
        [HttpPost]
        public  IHttpActionResult Insert( HttpRequestMessage request)
        {

            string obj =  request.Content.ReadAsStringAsync().Result;
            Models.Usuarios users = JsonConvert.DeserializeObject<Models.Usuarios>(obj);
   
            _unit.Usuarios.InsertUsuario(users);
            return Ok();
        }
    }
}
