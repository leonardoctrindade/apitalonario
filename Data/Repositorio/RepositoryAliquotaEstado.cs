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
    public class RepositoryAliquotaEstado: RepositoryGenerics<AliquotaEstado>, IAliquotaEstado
    {
        public Task<List<AliquotaEstado>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }

        public async Task<AliquotaEstado> GetAliquotaEstado(int id) 
        {
            var result = new AliquotaEstado();
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                result = await context.AliquotaEstado
                    .Include(c => c.EstadoDestino)
                    .Include(c => c.EstadoOrigem)
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();
            }

            return result;
        }
    }
}
