using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryEstado : RepositoryGenerics<Estado>, IEstado
    {
        public Task<List<Estado>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
