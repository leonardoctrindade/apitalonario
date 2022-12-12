using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryTurno: RepositoryGenerics<Turno>, ITurno
    {
        public Task<List<Turno>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
