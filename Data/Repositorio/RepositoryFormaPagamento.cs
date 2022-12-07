using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryFormaPagamento: RepositoryGenerics<FormaPagamento>, IFormaPagamento
    {
        public Task<List<FormaPagamento>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
