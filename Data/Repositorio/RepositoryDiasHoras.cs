using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryDiasHoras: RepositoryGenerics<DiasHoras>, IDiasHoras
    {
        public Task<List<DiasHoras>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
