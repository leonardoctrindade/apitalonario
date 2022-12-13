using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryBula : RepositoryGenerics<Bula>, IBula
    {
        public Task<List<Bula>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
