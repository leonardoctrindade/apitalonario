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
    public class RepositoryGrupo: RepositoryGenerics<Grupo>, IGrupo
    {
        public Task<List<Grupo>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }

        public async Task<Grupo> GetGrupo(int Id)
        {
            var result = new Grupo();
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                result = await context.Grupo
                    .Include(c => c.GrupoEnsaios)
                    .Where(x => x.Id == Id)
                    .SingleOrDefaultAsync();
            }

            return result;
        }
    }
}
