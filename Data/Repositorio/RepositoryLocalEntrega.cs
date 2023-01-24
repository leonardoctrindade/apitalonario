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
    public class RepositoryLocalEntrega : RepositoryGenerics<LocalEntrega>, ILocalEntrega
    {
        public async Task<List<LocalEntrega>> ListagemCustomizada(int pagina)
        {
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                var result = new List<LocalEntrega>();

                try
                {
                    result = await context.LocalEntrega
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

        public async Task<LocalEntrega> GetLocalEntrega(int id)
        {
            var result = new LocalEntrega();
            using (var context = new ContextBase(this._OptionsBuilder)) 
            {
                result = await context.LocalEntrega
                    .Include(c => c.Ncm)
                    .Include(c => c.Cfop)
                    .Include(c => c.Entregador)
                    .Include(c => c.Cst)
                    .Include(c => c.Csosn)
                    .Include(c => c.CodigoBeneficioFiscal)
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();
            }

            return result;
        }
    }
}
