using Data.Entidades;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class RepositoryPbm : RepositoryGenerics<Pbm>, IPbm
    {
        public Task<List<Pbm>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
