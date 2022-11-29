using Data.Entidades;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class RepositoryEspecialidade : RepositoryGenerics<Especialidade>, IEspecialidade
    {
        public Task<List<Especialidade>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
