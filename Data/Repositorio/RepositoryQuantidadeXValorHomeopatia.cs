using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryQuantidadeXValorHomeopatia: RepositoryGenerics<QuantidadeXValorHomeopatia>, IQuantidadeXValorHomeopatia
    {
        public Task<List<QuantidadeXValorHomeopatia>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
