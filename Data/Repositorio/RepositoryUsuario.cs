using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Data.Config;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Data.Repositorio
{
    public class RepositoryUsuario: RepositoryGenerics<Usuario>, IUsuario
    {
        public Task<List<Usuario>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            var result = new Usuario();
            using (var context = new ContextBase(this._OptionsBuilder)) 
            {
                result = await context.Usuario
                    .Include(c => c.GrupoUsuario)
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();
            }

            return result;
        }
    }
}
