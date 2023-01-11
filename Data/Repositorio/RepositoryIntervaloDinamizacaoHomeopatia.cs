using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryIntervaloDinamizacaoHomeopatia : RepositoryGenerics<IntervaloDinamizacaoHomeopatia>, IIntervaloDinamizacaoHomeopatia
    {
        public Task<List<IntervaloDinamizacaoHomeopatia>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
