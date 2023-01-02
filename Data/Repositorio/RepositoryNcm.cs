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
    public class RepositoryNcm : RepositoryGenerics<Ncm>, INcm
    {
        public Task<List<Ncm>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }

        public async Task<Ncm> GetNcm(int id)
        {
            var result = new Ncm();
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                result = await context.Ncm
                    .Include(c => c.TributoCstCofinsEntrada)
                    .Include(c => c.TributoCstCofinsSaida)
                    .Include(c => c.TributoCstPisEntrada)
                    .Include(c => c.TributoCstPisSaida)
                    .Include(c => c.NcmEstados)
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();
            }

            return result;
        }
    }
}
