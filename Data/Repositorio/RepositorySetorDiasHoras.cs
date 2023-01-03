using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositorySetorDiasHoras: RepositoryGenerics<SetorDiasHoras>, ISetorDiasHoras
    {
        public Task<List<SetorDiasHoras>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
