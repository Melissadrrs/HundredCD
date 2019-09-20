using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Usuarios
    {

        [BsonId]
        public ObjectId Id { get; set; }
        [Required]
        public string username { get; set; }
        public string password { get; set; }
        public string rol { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }


    }
}
