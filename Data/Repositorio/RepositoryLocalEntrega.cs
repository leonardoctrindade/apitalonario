using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryLocalEntrega : RepositoryGenerics<LocalEntrega>, ILocalEntrega
    {
        public Task<List<LocalEntrega>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
