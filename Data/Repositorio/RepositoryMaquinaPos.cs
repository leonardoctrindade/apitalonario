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
    public class RepositoryMaquinaPos : RepositoryGenerics<MaquinaPos>, IMaquinaPos
    {
        public Task<List<MaquinaPos>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }

        public async Task<MaquinaPos> GetMaquinaPos(int id)
        {
            var result = new MaquinaPos();
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                result = await context.MaquinaPos
                    .Include(c => c.AdquirentePos)
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();
            }

            return result;
        }
    }
}
