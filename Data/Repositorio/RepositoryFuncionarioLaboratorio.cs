using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryFuncionarioLaboratorio: RepositoryGenerics<FuncionarioLaboratorio>, IFuncionarioLaboratorio
    {
        public Task<List<FuncionarioLaboratorio>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
