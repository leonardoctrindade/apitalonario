using Data.Entidades;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class RepositoryDOM_RegimeTributario : RepositoryGenerics<DOM_RegimeTributario>, IDOM_RegimeTributario
    {
        public Task<List<DOM_RegimeTributario>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
