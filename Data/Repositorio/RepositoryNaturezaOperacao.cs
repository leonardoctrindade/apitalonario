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
    public class RepositoryNaturezaOperacao: RepositoryGenerics<NaturezaOperacao>, INaturezaOperacao
    {
        public Task<List<NaturezaOperacao>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }

        public async Task<NaturezaOperacao> GetNaturezaOperacao(int id)
        {
            var result = new NaturezaOperacao();
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                result = await context.NaturezaOperacao
                    .Include(c => c.Conta)
                    .Include(c => c.Cst)
                    .Include(c => c.Csosn)
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();
            }

            return result;
        }
    }
}
