using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryCidade : RepositoryGenerics<Cidade>, ICidade
    {
        public Task<List<Cidade>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
