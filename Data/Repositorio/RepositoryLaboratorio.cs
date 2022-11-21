using Data.Entidades;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    internal class RepositoryLaboratorio : RepositoryGenerics<Laboratorio>, ILaboratorio
    {
        public Task<List<Laboratorio>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
