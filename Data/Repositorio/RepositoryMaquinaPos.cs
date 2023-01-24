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
        public async Task<List<MaquinaPos>> ListagemCustomizada(int pagina)
        {
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                var result = new List<MaquinaPos>();

                try
                {
                    result = await context.MaquinaPos
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
