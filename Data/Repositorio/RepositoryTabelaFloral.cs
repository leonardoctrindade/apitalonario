using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryTabelaFloral: RepositoryGenerics<TabelaFloral>, ITabelaFloral
    {
        public Task<List<TabelaFloral>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
