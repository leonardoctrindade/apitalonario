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
    public class RepositoryEntregadorRegiao : RepositoryGenerics<EntregadorRegiao>, IEntregadorRegiao
    {
        public async Task<List<EntregadorRegiao>> ListagemCustomizada(int pagina)
        {
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                var result = new List<EntregadorRegiao>();

                try
                {
                    result = await context.EntregadorRegiao
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

        public async Task<EntregadorRegiao> GetEntregadorRegiao(int id)
        {
            var result = new EntregadorRegiao();
            using (var context = new ContextBase(this._OptionsBuilder)) 
            {
                result = await context.EntregadorRegiao
                    .Include(c => c.Regiao)
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();
            }

            return result;
        }
    }
}
