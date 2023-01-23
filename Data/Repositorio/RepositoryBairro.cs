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
    public class RepositoryBairro: RepositoryGenerics<Bairro>, IBairro
    {
        public async Task<List<Bairro>> ListagemCustomizada(int pagina)
        {
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                var result = new List<Bairro>();

                try
                {
                    result = await context.Bairro
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
