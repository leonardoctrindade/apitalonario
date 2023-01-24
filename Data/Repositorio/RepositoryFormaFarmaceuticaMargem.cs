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
    public class RepositoryFormaFarmaceuticaMargem: RepositoryGenerics<FormaFarmaceuticaMargem>, IFormaFarmaceuticaMargem
    {
        public async Task<List<FormaFarmaceuticaMargem>> ListagemCustomizada(int pagina)
        {
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                var result = new List<FormaFarmaceuticaMargem>();

                try
                {
                    result = await context.FormaFarmaceuticaMargem
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
