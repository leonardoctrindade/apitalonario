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
    public class RepositoryFormaFarmaceutica: RepositoryGenerics<FormaFarmaceutica>, IFormaFarmaceutica
    {
        public Task<List<FormaFarmaceutica>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }

        public async Task<FormaFarmaceutica> GetFormaFarmaceutica(int id)
        {
            var result = new FormaFarmaceutica();
            using (var context = new ContextBase(this._OptionsBuilder)) 
            {
                result = await context.FormaFarmaceutica
                    .Include(c => c.Manipulador)
                    .Include(c => c.Ncm)
                    .Include(c => c.ProdutoVeiculo)
                    .Include(c => c.GrupoVeiculo)
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();
            }

            return result;
        }
    }
}
