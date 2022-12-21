using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryFidelidadePremios: RepositoryGenerics<FidelidadePremios>, IFidelidadePremios
    {
        public Task<List<FidelidadePremios>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
