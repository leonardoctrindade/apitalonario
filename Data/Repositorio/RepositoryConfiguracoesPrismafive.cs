using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryConfiguracoesPrismafive: RepositoryGenerics<ConfiguracoesPrismafive>, IConfiguracoesPrismafive
    {
        public Task<List<ConfiguracoesPrismafive>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
