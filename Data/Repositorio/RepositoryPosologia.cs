using Data.Entidades;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class RepositoryPosologia: RepositoryGenerics<Posologia>, IPosologia
    {
        public Task<List<Posologia>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
