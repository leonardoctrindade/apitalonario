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
        public Task<List<VendedorComissao>> ListagemCustomizada()
        {
            throw new NotImplementedException();
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
