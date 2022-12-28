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
    public class RepositoryNcmEstado: RepositoryGenerics<NcmEstado>, INcmEstado
    {
        public Task<List<NcmEstado>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }

        public async Task<NcmEstado> GetNcmEstado(int id)
        {
            var result = new NcmEstado();
            using (var context = new ContextBase(this._OptionsBuilder)) 
            {
                result = await context.NcmEstado
                    .Include(c => c.EstadoOrigem)
                    .Include(c => c.EstadoDestino)
                    .Include(c => c.TributoCst)
                    .Include(c => c.TributoCsosn)
                    .Include(c => c.Ncm)
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();
            }

            return result;
        }
    }
}
