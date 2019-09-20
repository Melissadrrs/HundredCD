using Microsoft.Extensions.Options;
using MongoDB.Bson;
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
    public class UsuariosService : IUsuariosService
    {

        private readonly MongoRepository _repository = null;
        public UsuariosService(Settings settings)
        {
            _repository = new MongoRepository(settings);
        }


        public bool ValidateUsuario(string username,string password)
        {
            var obj= _repository.usuarios.Find(x => x.username== username && x.password==password).ToListAsync();
            if (obj != null && obj.Result.Count > 0) return true;
            else return false;
        }

        public async Task<IEnumerable<Usuarios>> GetAllUsuarios()
        {
            return await _repository.usuarios.Find(x => true).ToListAsync();
        }

        public  void InsertUsuario(Usuarios user)
        {
              _repository.usuarios.InsertOneAsync(user);
        }

    }

        
}