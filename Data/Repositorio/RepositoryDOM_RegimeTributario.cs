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
    public class RepositoryDOM_RegimeTributario : RepositoryGenerics<DOM_RegimeTributario>, IDOM_RegimeTributario
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryDOM_RegimeTributario()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<DOM_RegimeTributario> RetornaRegimeTributarioPorID(int idRegimeTributario)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                return await data.Set<DOM_RegimeTributario>().Where(x => x.Id == idRegimeTributario).FirstOrDefaultAsync();
            }

        }
    }
}
