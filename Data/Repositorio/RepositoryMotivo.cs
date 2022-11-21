using Data.Entidades;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class RepositoryMotivo : RepositoryGenerics<Motivo>, IMotivo
    {
        public Task<List<Motivo>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
