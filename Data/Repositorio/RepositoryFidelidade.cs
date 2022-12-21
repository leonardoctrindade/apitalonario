using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryFidelidade: RepositoryGenerics<Fidelidade>, IFidelidade
    {
        public Task<List<Fidelidade>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
