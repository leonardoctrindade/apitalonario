using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Data.Config;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Data.Repositorio
{
    public class RepositoryConvenio : RepositoryGenerics<Convenio>, IConvenio
    {
        public Task<List<Convenio>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }

        public async Task<Convenio> GetConvenio(int id)
        {
            var result = new Convenio();
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                result = await context.Convenio
                    .Include(c => c.Bairro)
                    .Include(c => c.Cidade)
                    .Include(c => c.Estado)
                    .Include(c => c.Visitador)
                    .Include(c => c.ConvenioGrupos)
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();
            }

            return result;
        }
    }
}
