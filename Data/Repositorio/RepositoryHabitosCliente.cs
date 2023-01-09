using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryHabitosCliente : RepositoryGenerics<HabitosCliente>, IHabitosCliente
    {
        public Task<List<HabitosCliente>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
