using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryReacoesAdversas: RepositoryGenerics<ReacoesAdversas>, IReacoesAdversas
    {
        public Task<List<ReacoesAdversas>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
