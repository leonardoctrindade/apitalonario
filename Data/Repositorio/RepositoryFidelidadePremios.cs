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
    public class RepositoryFidelidadePremios: RepositoryGenerics<FidelidadePremios>, IFidelidadePremios
    {
        public async Task<List<FidelidadePremios>> ListagemCustomizada(int pagina)
        {
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                var result = new List<FidelidadePremios>();

                try
                {
                    result = await context.FidelidadePremios
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

        public async Task<FidelidadePremios> GetFidelidadePremios(int id)
        {
            var result = new FidelidadePremios();
            using (var context = new ContextBase(this._OptionsBuilder)) 
            {
                result = await context.FidelidadePremios
                    .Include(c => c.Grupo)
                    .Include(c => c.Produto)
                    .Include(c => c.Fidelidade)
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();
            }

            return result;
        }
    }
}
