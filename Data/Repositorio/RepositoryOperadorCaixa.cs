using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryOperadorCaixa: RepositoryGenerics<OperadorCaixa>, IOperadorCaixa
    {
        public Task<List<OperadorCaixa>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
