using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.DataLayer.MongoSettings
{

    public class MongoRepository
    {
        //delcaring mongo db
        private readonly IMongoDatabase _database;

        public MongoRepository(Settings settings)
        {
            try
            {
                var cn = new MongoClient(settings.ConnectionString);
                if (cn != null)
                    _database = cn.GetDatabase(settings.Database);
            }
            catch (Exception ex)
            {
                throw new Exception("Can not access to MongoDb server.", ex);
            }

        }

        public IMongoCollection<Clientes> clients => _database.GetCollection<Clientes>("clientes");
        public IMongoCollection<Usuarios> usuarios => _database.GetCollection<Usuarios>("usuarios");

    }
}