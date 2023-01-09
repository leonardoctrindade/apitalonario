using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryRestricaoDeUso: RepositoryGenerics<RestricaoDeUso>, IRestricaoDeUso
    {
        public Task<List<RestricaoDeUso>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
