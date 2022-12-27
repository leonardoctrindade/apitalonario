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
    public class RepositoryTransportador : RepositoryGenerics<Transportador>, ITransportador
    {
        public Task<List<Transportador>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }

        public async Task<Transportador> GetTransportador(int id)
        {
            var result = new Transportador();
            using (var context = new ContextBase(this._OptionsBuilder)) 
            {
                result = await context.Transportador
                    .Include(c => c.Bairro)
                    .Include(c => c.Cidade)
                    .Include(c => c.Estado)
                    .Include(c => c.EstadoPlaca)
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();
            }

            return result;
        }
    }
}
