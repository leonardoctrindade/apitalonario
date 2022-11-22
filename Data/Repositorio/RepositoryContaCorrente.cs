using Data.Entidades;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class RepositoryContaCorrente : RepositoryGenerics<ContaCorrente>, IContaCorrente
    {
        public Task<List<ContaCorrente>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
