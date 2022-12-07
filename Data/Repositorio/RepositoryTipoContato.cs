using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryTipoContato: RepositoryGenerics<TipoContato>, ITipoContato
    {
        public Task<List<TipoContato>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
