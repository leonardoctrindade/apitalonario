using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryGrupoUsuario : RepositoryGenerics<GrupoUsuario>, IGrupoUsuario
    {
        public Task<List<GrupoUsuario>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
