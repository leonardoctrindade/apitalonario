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
    public class RepositoryEstado : RepositoryGenerics<Estado>, IEstado
    {
        public Task<List<Estado>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }

        public async Task<Estado> GetEstado(int id)
        {
            var result = new Estado();
            using (var context = new ContextBase(this._OptionsBuilder)) 
            {
                result = await context.Estado
                    .Include(c => c.Pais)
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();
            }

            return result;
        }
    }
}
