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
    public class RepositoryClasse : RepositoryGenerics<Classe>,IClasse
    {
        public async Task<List<Classe>> ListagemCustomizada(int pagina)
        {
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                var result = new List<Classe>();

                try
                {
                    result = await context.Classe
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
