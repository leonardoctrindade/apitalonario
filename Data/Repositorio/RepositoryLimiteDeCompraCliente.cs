using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryLimiteDeCompraCliente: RepositoryGenerics<LimiteDeCompraCliente>, ILimiteDeCompraCliente
    {
        public Task<List<LimiteDeCompraCliente>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
