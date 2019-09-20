using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.DataLayer.MongoSettings
{
    public class Settings
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }
}

