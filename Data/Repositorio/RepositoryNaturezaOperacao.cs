using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryNaturezaOperacao: RepositoryGenerics<NaturezaOperacao>, INaturezaOperacao
    {
        public Task<List<NaturezaOperacao>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
