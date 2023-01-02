using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryTipoCapsula: RepositoryGenerics<TipoCapsula>, ITipoCapsula
    {
        public Task<List<TipoCapsula>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
