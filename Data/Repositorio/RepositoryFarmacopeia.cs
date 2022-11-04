using Data.Entidades;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class RepositoryFarmacopeia : RepositoryGenerics<Farmacopeia>, IFarmacopeia
    {
        public Task<List<Pbm>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
