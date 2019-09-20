using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebApi.DataLayer.Abstracts;
using WebApi.Models;

namespace WebApi.Controllers
{
    [RoutePrefix("client")]
    public class ClientesController : BaseController
    {
        public ClientesController(IUnitOfWork unit) : base(unit)
        {
            
        }
        [HttpGet]
        [Route("getClientes")]
        public Task<IEnumerable<Clientes>> Get()
        {
            return _unit.Clientes.GetAllClientes();
        }
    }
}