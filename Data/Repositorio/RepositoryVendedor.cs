using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryVendedor: RepositoryGenerics<Vendedor>, IVendedor
    {
        public Task<List<Vendedor>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
