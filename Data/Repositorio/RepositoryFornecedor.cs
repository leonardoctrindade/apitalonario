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
    public class RepositoryFornecedor: RepositoryGenerics<Fornecedor>, IFornecedor
    {
        public async Task<List<Fornecedor>> ListagemCustomizada(int pagina)
        {
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                var result = new List<Fornecedor>();

                try
                {
                    result = await context.Fornecedor
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

        public async Task<Fornecedor> GetFornecedor(int id)
        {
            var result = new Fornecedor();
            using (var context = new ContextBase(this._OptionsBuilder)) 
            {
                result = await context.Fornecedor
                    .Include(c => c.Bairro)
                    .Include(c => c.Cidade)
                    .Include(c => c.Estado)
                    .Include(c => c.Banco)
                    .Include(c => c.PlanoDeConta)
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();
            }

            return result;
        }
    }
}
