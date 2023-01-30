using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Data.Config;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositorio
{
    public class RepositoryOperadorCaixa: RepositoryGenerics<OperadorCaixa>, IOperadorCaixa
    {
        public async Task<List<OperadorCaixa>> ListagemCustomizada(int pagina)
        {
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                var result = new List<OperadorCaixa>();

                try
                {
                    result = await context.OperadorCaixa
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

        public async Task<OperadorCaixa> GetOperadorCaixa(int id)
        {
            var result = new OperadorCaixa();
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                result = await context.OperadorCaixa
                    .Include(c => c.Usuario)
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();
            }

            return result;
        }
    }
}
