using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApi.Domain.Entities;
using UsuariosApi.Domain.Interfaces.Repositories;
using UsuariosApi.Infra.Data.Contexts;

namespace UsuariosApi.Infra.Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {

        public Usuario Get(string email)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Usuario
                    .FirstOrDefault(u => u.Email.Equals(email));
            }
        }

        public Usuario GetByEmail(string email, string senha)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Usuario
                    .FirstOrDefault(u => u.Email.Equals(email) && u.Senha.Equals(senha));
            }
        }
    }
}
