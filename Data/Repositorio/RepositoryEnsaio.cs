using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryEnsaio : RepositoryGenerics<Ensaio>, IEnsaio
    {
        public Task<List<Ensaio>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
