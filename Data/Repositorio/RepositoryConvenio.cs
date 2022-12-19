using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryConvenio : RepositoryGenerics<Convenio>, IConvenio
    {
        public Task<List<Convenio>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
