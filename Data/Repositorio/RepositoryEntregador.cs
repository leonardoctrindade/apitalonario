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
    public class RepositoryEntregador: RepositoryGenerics<Entregador>, IEntregador
    {
        public async Task<List<Entregador>> ListagemCustomizada(int pagina)
        {
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                var result = new List<Entregador>();

                try
                {
                    result = await context.Entregador
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

        public async Task<Entregador> GetEntregador(int id)
        {
            var result = new Entregador();
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                result = await context.Entregador
                    .Include(c => c.EntregadorRegiao)
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();
            }

            return result;
        }
    }
}
