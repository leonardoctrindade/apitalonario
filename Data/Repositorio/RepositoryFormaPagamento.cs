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
    public class RepositoryFormaPagamento: RepositoryGenerics<FormaPagamento>, IFormaPagamento
    {
        public async Task<List<FormaPagamento>> ListagemCustomizada(int pagina)
        {
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                var result = new List<FormaPagamento>();

                try
                {
                    result = await context.FormaPagamento
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

        public async Task<FormaPagamento> GetFormaPagamento(int id)
        {
            var result = new FormaPagamento();
            using (var context = new ContextBase(this._OptionsBuilder)) 
            {
                result = await context.FormaPagamento
                    .Include(c => c.PlanoDeConta)
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();
            }

            return result;
        }
    }
}
