using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryUsuario: RepositoryGenerics<Usuario>, IUsuario
    {
        public Task<List<Usuario>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
