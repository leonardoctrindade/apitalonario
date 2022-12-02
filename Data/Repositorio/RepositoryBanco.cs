using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryBanco : RepositoryGenerics<Banco>, IBanco
    {
        public Task<List<Banco>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
