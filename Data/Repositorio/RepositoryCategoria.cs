using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryCategoria: RepositoryGenerics<Categoria>, ICategoria 
    {
        public Task<List<Categoria>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
