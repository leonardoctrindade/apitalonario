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
    public class RepositoryGrupoEnsaio: RepositoryGenerics<GrupoEnsaio>, IGrupoEnsaio
    {
        public Task<List<GrupoEnsaio>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }

        public async Task<GrupoEnsaio> GetGrupoEnsaio(int Id)
        {
            var result = new GrupoEnsaio();
            using (var context = new ContextBase(this._OptionsBuilder)) 
            {
                result = await context.GrupoEnsaio
                    .Include(c => c.Ensaio)
                    .Include(c => c.Grupo)
                    .Where(x => x.Id == Id)
                    .SingleOrDefaultAsync();
            }

            return result;
        }
    }
}
