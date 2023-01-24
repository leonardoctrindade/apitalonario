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
        public async Task<List<FormaFarmaceutica>> ListagemCustomizada(int pagina)
        {
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                var result = new List<FormaFarmaceutica>();

                try
                {
                    result = await context.FormaFarmaceutica
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
                    .Include(c => c.FormaFarmaceuticaEnsaios)
                    .Include(c => c.FormaFarmaceuticaMargens)
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();
            }

            return result;
        }
    }
}
