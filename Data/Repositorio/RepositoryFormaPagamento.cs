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
        public Task<List<FormaPagamento>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }

        public async Task<FormaPagamento> GetFormaPagamento(int id)
        {
            var result = new FormaPagamento();
            using (var context = new ContextBase(this._OptionsBuilder)) 
            {
                result = await context.FormaPagamento
                    .Include(c => c.Conta)
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();
            }

            return result;
        }
    }
}
