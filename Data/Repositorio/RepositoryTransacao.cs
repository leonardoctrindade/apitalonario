using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryTransacao: RepositoryGenerics<Transacao>, ITransacao
    {
        public Task<List<Transacao>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
