using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryVendedorComissao: RepositoryGenerics<VendedorComissao>, IVendedorComissao
    {
        public Task<List<VendedorComissao>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
