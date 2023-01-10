using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryEnderecoEntregaCliente: RepositoryGenerics<EnderecoEntregaCliente>, IEnderecoEntregaCliente
    {
        public Task<List<EnderecoEntregaCliente>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
