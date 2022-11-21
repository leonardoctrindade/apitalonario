using Data.Entidades;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class RepositoryNbm : RepositoryGenerics<Nbm>, INbm
    {
        public Task<List<Nbm>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
