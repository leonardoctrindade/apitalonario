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
        public Task<List<Unidade>> ListagemCustomizada()
        {
            throw new NotImplementedException();
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
