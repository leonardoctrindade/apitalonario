using Data.Config;
using Data.Entidades;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositorio
{
    public class RepositoryTipoJustificativa : RepositoryGenerics<TipoJustificativa>, ITipoJustificativa
    {
        public async Task<List<TipoJustificativa>> ListagemCustomizada(int pagina)
        {
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                var result = new List<TipoJustificativa>();

                try
                {
                    result = await context.TipoJustificativa
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
    }
}
