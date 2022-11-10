using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

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
