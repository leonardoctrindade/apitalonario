using System;
using Data.Config;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Data.Repositorio
{
    public class RepositoryVendedor: RepositoryGenerics<Vendedor>, IVendedor
    {
        public Task<List<Vendedor>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }

        public async Task<Vendedor> GetVendedor(int id)
        {
            var result = new Vendedor();
            using (var context = new ContextBase(this._OptionsBuilder)) 
            {
                result = await context.Vendedor
                    .Include(c => c.Bairro)
                    .Include(c => c.Cidade)
                    .Include(c => c.Estado)
                    .Include(c => c.Usuario)
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();
            }

            return result;
        }
    }
}
