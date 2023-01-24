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
        public async Task<List<Grupo>> ListagemCustomizada(int pagina)
        {
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                var result = new List<Grupo>();

                try
                {
                    result = await context.Grupo
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
