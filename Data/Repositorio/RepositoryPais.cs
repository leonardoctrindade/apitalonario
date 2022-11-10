using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryPais : RepositoryGenerics<Pais>, IPais
    {
        public Task<List<Pais>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
