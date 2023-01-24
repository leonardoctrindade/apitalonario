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
        public async Task<List<NaturezaOperacao>> ListagemCustomizada(int pagina)
        {
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                var result = new List<NaturezaOperacao>();

                try
                {
                    result = await context.NaturezaOperacao
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

        public async Task<NaturezaOperacao> GetNaturezaOperacao(int id)
        {
            var result = new NaturezaOperacao();
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                result = await context.NaturezaOperacao
                    .Include(c => c.PlanoDeConta)
                    .Include(c => c.Cst)
                    .Include(c => c.Csosn)
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();
            }

            return result;
        }
    }
}
