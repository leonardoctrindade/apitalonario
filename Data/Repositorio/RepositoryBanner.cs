using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryBanner: RepositoryGenerics<Banner>, IBanner
    {
        public Task<List<Banner>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
