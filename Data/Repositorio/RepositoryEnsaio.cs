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
    public class RepositoryEnsaio : RepositoryGenerics<Ensaio>, IEnsaio
    {
        public Task<List<Ensaio>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }

        public async Task<Ensaio> GetEnsaio(int id)
        {
            var result = new Ensaio();
            using (var context = new ContextBase(this._OptionsBuilder)) 
            {
                result = await context.Ensaio
                    .Include(c => c.Farmacopeia)
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();
            }

            return result;
        }
    }
}
