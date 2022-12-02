using Data.Entidades;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class RepositoryPosAdquirente :RepositoryGenerics<PosAdquirente>, IPosAdquirente
    {
        public Task<List<PosAdquirente>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
