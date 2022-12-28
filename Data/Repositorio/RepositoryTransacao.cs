using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Data.Config;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Data.Repositorio
{
    public class RepositoryTransacao: RepositoryGenerics<Transacao>, ITransacao
    {
        public Task<List<Transacao>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }

        public async Task<Transacao> GetTransacao(int id)
        {
            var result = new Transacao();
            using (var context = new ContextBase(this._OptionsBuilder)) 
            {
                result = await context.Transacao
                    .Include(c => c.Fornecedor)
                    .Include(c => c.Conta)
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();
            }

            return result;
        }
    }
}
