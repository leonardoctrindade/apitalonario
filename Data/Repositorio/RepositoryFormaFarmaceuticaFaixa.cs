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
        public Task<List<FormaFarmaceuticaFaixa>> ListagemCustomizada()
        { 
            throw new NotFiniteNumberException();
        }

        public async Task<FormaFarmaceuticaFaixa> GetFormaFarmaceuticaFaixa(int id)
        {
            var result = new FormaFarmaceuticaFaixa();
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                result = await context.FormaFarmaceuticaFaixa
                    .Include(c => c.FormaFarmaceutica)
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();
            }

            return result;
        }
    }
}
