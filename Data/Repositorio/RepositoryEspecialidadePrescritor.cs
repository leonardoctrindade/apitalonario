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
    public class RepositoryEspecialidadePrescritor : RepositoryGenerics<EspecialidadePrescritor>, IEspecialidadePrescritor
    {
        public Task<List<EspecialidadePrescritor>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }

        public async Task<EspecialidadePrescritor> GetEspecialidadePrescritor(int id)
        {
            var result = new EspecialidadePrescritor();
            using (var context = new ContextBase(this._OptionsBuilder)) 
            {
                result = await context.EspecialidadePrescritor
                    .Include(c => c.Especialidade)
                    .Include(c => c.Prescritor)
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();
            }

            return result;
        }
    }
}
