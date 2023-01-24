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
    public class RepositoryFormaFarmaceuticaFaixa: RepositoryGenerics<FormaFarmaceuticaFaixa>, IFormaFarmaceuticaFaixa
    {
        public async Task<List<FormaFarmaceuticaFaixa>> ListagemCustomizada(int pagina)
        {
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                var result = new List<FormaFarmaceuticaFaixa>();

                try
                {
                    result = await context.FormaFarmaceuticaFaixa
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
