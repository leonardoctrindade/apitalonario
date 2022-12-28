using Data.Config;
using Data.Entidades;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class RepositoryVisitador : RepositoryGenerics<Visitador>, IVisitador
    {
        public Task<List<Visitador>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }

        public async Task<Visitador> GetVisitador(int id)
        {
            var result = new Visitador();
            using (var context = new ContextBase(this._OptionsBuilder)) 
            {
                result = await context.Visitador
                    .Include(c => c.Bairro)
                    .Include(c => c.Cidade)
                    .Include(c => c.Estado)
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();
            }

            return result;
        }
    }
}
