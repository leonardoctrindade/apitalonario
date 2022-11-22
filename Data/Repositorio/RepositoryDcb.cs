using Data.Entidades;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class RepositoryDcb : RepositoryGenerics<Dcb>, IDcb
    {
        public Task<List<Dcb>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
