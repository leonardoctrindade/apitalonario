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
    public class RepositoryCidade : RepositoryGenerics<Cidade>, ICidade
    {
        public Task<List<Cidade>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }

        public async Task<Cidade> GetCidade(int id)
        {
            var result = new Cidade();
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                result = await context.Cidade
                    .Include(c => c.CodigoCfps)
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();
            }

            return result;
        }
    }
}
