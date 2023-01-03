using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositorySetor: RepositoryGenerics<Setor>, ISetor
    {
        public Task<List<Setor>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
