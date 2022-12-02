using Data.Entidades;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class RepositoryPortador: RepositoryGenerics<Portador>, IPortador
    {
        public Task<List<Portador>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
