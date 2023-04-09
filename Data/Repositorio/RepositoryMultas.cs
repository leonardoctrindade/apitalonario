using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Data.Config;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Data.Helper;

namespace Data.Repositorio
{
    public class RepositoryMultas : RepositoryGenerics<Multas>, IMultas
    {
        public async Task<List<Multas>> ListagemCustomizada(int pagina)
        {
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                var result = new List<Multas>();

                try
                {
                    result = await context.Multas
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

        public async Task<Multas> BuscarMulta(int matricula, string placa, DateTime data, string hora, string infracao)
        {
            try
            {
                using (var context = new ContextBase(_OptionsBuilder))
                {
                    return await context.Multas.Where(x => x.idMatricula == matricula && x.Placa == placa && x.Data == data && x.Hora == hora).FirstOrDefaultAsync();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }


    }
}
