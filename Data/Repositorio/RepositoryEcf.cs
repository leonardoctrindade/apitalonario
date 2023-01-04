using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryEcf: RepositoryGenerics<Ecf>, IEcf
    {
        public Task<List<Ecf>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
