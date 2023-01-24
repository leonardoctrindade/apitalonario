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
    public class RepositoryContabilista : RepositoryGenerics<Contabilista>, IContabilista
    {
        public async Task<List<Contabilista>> ListagemCustomizada(int pagina)
        {
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                var result = new List<Contabilista>();

                try
                {
                    result = await context.Contabilista
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

        public async Task<Contabilista> GetContabilista(int id)
        {
            var result = new Contabilista();
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                result = await context.Contabilista
                    .Include(c => c.Bairro)
                    .Include(c => c.Cidade)
                    .Include(c => c.Estado)
                    .Where(c => c.Id == id)
                    .SingleOrDefaultAsync();
            }

            return result;
        }
    }
}
