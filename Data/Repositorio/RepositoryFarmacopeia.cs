using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryFarmacopeia : RepositoryGenerics<Farmacopeia>, IFarmacopeia
    {
        public Task<List<Farmacopeia>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
