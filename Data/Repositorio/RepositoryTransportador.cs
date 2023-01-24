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
        public async Task<List<Transportador>> ListagemCustomizada(int pagina)
        {
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                var result = new List<Transportador>();

                try
                {
                    result = await context.Transportador
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
