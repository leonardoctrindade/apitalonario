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
        public Task<List<EntregadorRegiao>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }

        public async Task<EntregadorRegiao> GetEntregadorRegiao(int id)
        {
            var result = new EntregadorRegiao();
            using (var context = new ContextBase(this._OptionsBuilder)) 
            {
                result = await context.EntregadorRegiao
                    .Include(c => c.Entregador)
                    .Include(c => c.Regiao)
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();
            }

            return result;
        }
    }
}
