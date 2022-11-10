using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryTributo : RepositoryGenerics<Tributo>, ITributo
    {
        public Task<List<Tributo>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
