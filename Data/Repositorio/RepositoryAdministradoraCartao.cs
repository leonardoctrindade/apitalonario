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
    public class RepositoryAdministradoraCartao: RepositoryGenerics<AdministradoraCartao>, IAdministradoraCartao
    {
        public Task<List<AdministradoraCartao>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }

        public async Task<AdministradoraCartao> GetAdministradoraCartao(int id)
        {
            var result = new AdministradoraCartao();
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                result = await context.AdministradoraCartao.Include(c => c.Fornecedor).Include(c => c.Conta).Where(x => x.Id == id).SingleOrDefaultAsync();
            }

            return result;
        }
    }
}
