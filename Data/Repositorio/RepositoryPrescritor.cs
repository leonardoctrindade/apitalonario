using Data.Entidades;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class RepositoryPrescritor : RepositoryGenerics<Prescritor>, IPrescritor
    {
        public Task<List<Prescritor>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
