using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryObservacoesCliente: RepositoryGenerics<ObservacoesCliente>, IObservacoesCliente
    {
        public Task<List<ObservacoesCliente>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
