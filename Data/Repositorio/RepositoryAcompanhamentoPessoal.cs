using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryAcompanhamentoPessoal: RepositoryGenerics<AcompanhamentoPessoal>, IAcompanhamentoPessoal
    {
        public Task<List<AcompanhamentoPessoal>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
