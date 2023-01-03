using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryBalanca: RepositoryGenerics<Balanca>, IBalanca
    {
        public Task<List<Balanca>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
