using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryEntregador: RepositoryGenerics<Entregador>, IEntregador
    {
        public Task<List<Entregador>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
