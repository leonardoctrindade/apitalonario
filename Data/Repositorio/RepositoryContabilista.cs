using Data.Entidades;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class RepositoryContabilista : RepositoryGenerics<Contabilista>, IContabilista
    {
        public Task<List<Contabilista>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
