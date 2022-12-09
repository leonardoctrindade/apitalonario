using Data.Entidades;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class RepositoryPlanoDeContas : RepositoryGenerics<PlanoDeContas>, IPlanoDeContas
    {
        public Task<List<PlanoDeContas>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
