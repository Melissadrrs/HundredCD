using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.DataLayer.Abstracts
{
    public interface IUsuariosService
    {
        bool ValidateUsuario(string username, string password);
        void InsertUsuario(Usuarios user);
        Task<IEnumerable<Usuarios>> GetAllUsuarios();
    }
}
