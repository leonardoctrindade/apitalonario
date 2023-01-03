using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryEtiqueta: RepositoryGenerics<Etiqueta>, IEtiqueta
    {
        public Task<List<Etiqueta>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
