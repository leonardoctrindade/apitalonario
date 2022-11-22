using Data.Entidades;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class RepositoryPrincipioAtivo : RepositoryGenerics<PrincipioAtivo>, IPrincipioAtivo
    {
        public Task<List<PrincipioAtivo>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
