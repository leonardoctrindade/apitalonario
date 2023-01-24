using Data.Config;
using Data.Entidades;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class RepositoryUnidade : RepositoryGenerics<Unidade>, IUnidade
    {
        public async Task<List<Unidade>> ListagemCustomizada(int pagina)
        {
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                var result = new List<Unidade>();

                try
                {
                    result = await context.Unidade
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

        public async Task<Unidade> GetUnidade(int id)
        {
            var result = new Unidade();
            using (var context = new ContextBase(this._OptionsBuilder)) 
            {
                result = await context.Unidade
                    .Include(c => c.UnidadesConversao)
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();
            }

            return result;
        }
    }
}
