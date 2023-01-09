using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryNfeExpedicaoCliente: RepositoryGenerics<NfeExpedicaoCliente>, INfeExpedicaoCliente
    {
        public Task<List<NfeExpedicaoCliente>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
