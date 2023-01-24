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
    public class RepositoryVendedorComissao: RepositoryGenerics<VendedorComissao>, IVendedorComissao
    {
        public async Task<List<VendedorComissao>> ListagemCustomizada(int pagina)
        {
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                var result = new List<VendedorComissao>();

                try
                {
                    result = await context.VendedorComissao
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

        public async Task<VendedorComissao> GetVendedorComissao(int id)
        {
            var result = new VendedorComissao();
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                result = await context.VendedorComissao
                    .Include(c => c.Vendedor)
                    .Include(c => c.Grupo)
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();
            }

            return result;
        }
    }
}
