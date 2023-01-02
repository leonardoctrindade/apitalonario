using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryFormaFarmaceuticaEnsaio : RepositoryGenerics<FormaFarmaceuticaEnsaio>, IFormaFarmaceuticaEnsaio
    {
        public Task<List<FormaFarmaceuticaEnsaio>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
