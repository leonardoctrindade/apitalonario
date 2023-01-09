using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Data.Repositorio
{
    public class RepositoryPaciente: RepositoryGenerics<Paciente>, IPaciente
    {
        public Task<List<Paciente>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
