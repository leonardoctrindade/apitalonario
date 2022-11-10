using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryProduto : RepositoryGenerics<Produto>, IProduto
    {
        public Task<List<Produto>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
