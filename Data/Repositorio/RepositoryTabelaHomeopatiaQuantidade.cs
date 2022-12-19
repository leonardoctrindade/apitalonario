using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryTabelaHomeopatiaQuantidade: RepositoryGenerics<TabelaHomeopatiaQuantidade>, ITabelaHomeopatiaQuantidade
    {
        public Task<List<TabelaHomeopatiaQuantidade>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
