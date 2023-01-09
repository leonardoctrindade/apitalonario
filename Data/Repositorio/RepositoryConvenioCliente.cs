using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryConvenioCliente: RepositoryGenerics<ConvenioCliente>, IConvenioCliente
    {
        public Task<List<ConvenioCliente>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
