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
    public class RepositoryIntervaloDinamizacaoHomeopatia : RepositoryGenerics<IntervaloDinamizacaoHomeopatia>, IIntervaloDinamizacaoHomeopatia
    {
        public async Task<List<IntervaloDinamizacaoHomeopatia>> ListagemCustomizada(int pagina)
        {
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                var result = new List<IntervaloDinamizacaoHomeopatia>();

                try
                {
                    result = await context.IntervaloDinamizacaoHomeopatia
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
    }
}
