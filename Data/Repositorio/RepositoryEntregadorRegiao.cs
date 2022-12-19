using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryEntregadorRegiao : RepositoryGenerics<EntregadorRegiao>, IEntregadorRegiao
    {
        public Task<List<EntregadorRegiao>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
