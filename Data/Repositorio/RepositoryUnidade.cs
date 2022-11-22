using Data.Entidades;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class RepositoryUnidade : RepositoryGenerics<Unidade>, IUnidade
    {
        public Task<List<Unidade>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
