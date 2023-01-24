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
        public async Task<List<Estado>> ListagemCustomizada(int pagina)
        {
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                var result = new List<Estado>();

                try
                {
                    result = await context.Estado
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
