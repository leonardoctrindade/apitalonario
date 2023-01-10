using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryCliente: RepositoryGenerics<Cliente>, ICliente
    {
        public Task<List<Cliente>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
