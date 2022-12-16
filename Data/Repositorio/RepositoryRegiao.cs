using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryRegiao: RepositoryGenerics<Regiao>, IRegiao
    {
        public Task<List<Regiao>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
