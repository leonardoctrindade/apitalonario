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
        public async Task<List<Usuario>> ListagemCustomizada(int pagina)
        {
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                var result = new List<Usuario>();

                try
                {
                    result = await context.Usuario
                   .OrderBy(x => x.Id)
                   .Skip((pagina - 1) * 10)
                   .Take(10)
                   .ToListAsync();
                }
                catch (Exception)
                {

                    throw;
                }


                return result;
            }
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
