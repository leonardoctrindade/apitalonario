using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Data.Config;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Data.Helper;

namespace Data.Repositorio
{
    public class RepositoryUsuario : RepositoryGenerics<Usuario>, IUsuario
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

        public async Task<Usuario> BuscarUsuario(int matricula, string senha)
        {
            try
            {
                using (var context = new ContextBase(this._OptionsBuilder))
                {
                    return await context.Usuario.Where(x => x.Matricula == matricula && x.Senha == senha).FirstOrDefaultAsync();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
