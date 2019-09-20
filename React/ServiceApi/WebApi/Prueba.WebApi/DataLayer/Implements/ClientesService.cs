using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApi.DataLayer.Abstracts;
using WebApi.DataLayer.MongoSettings;
using WebApi.Models;

namespace WebApi.DataLayer.Implements
{
    public class ClientesService : IClientesService
    {

        private readonly MongoRepository _repository = null;
        public ClientesService(Settings settings)
        {
            _repository = new MongoRepository(settings);
        }

        public async Task<IEnumerable<Clientes>> GetAllClientes()
        {
            return await _repository.clients.Find(x => true).ToListAsync();
        }

    }

        
}