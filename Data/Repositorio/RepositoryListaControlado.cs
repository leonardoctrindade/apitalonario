using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryListaControlado: RepositoryGenerics<ListaControlado>, IListaControlado
    {
        public Task<List<ListaControlado>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
