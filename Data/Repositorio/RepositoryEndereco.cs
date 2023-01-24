using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryEndereco: RepositoryGenerics<Endereco>, IEndereco
    {
        public Task<List<Endereco>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
