using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryTabelaHomeopatia: RepositoryGenerics<TabelaHomeopatia>, ITabelaHomeopatia
    {
        public Task<List<TabelaHomeopatia>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
