using Data.Entidades;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class RepositoryTransportador : RepositoryGenerics<Transportador>, ITransportador
    {
        public Task<List<Transportador>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
