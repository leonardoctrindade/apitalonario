using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryMetodo: RepositoryGenerics<Metodo>, IMetodo
    {
        public Task<List<Metodo>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
