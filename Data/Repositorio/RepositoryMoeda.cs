using Data.Entidades;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class RepositoryMoeda : RepositoryGenerics<Moeda>, IMoeda
    {
        public Task<List<Moeda>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
