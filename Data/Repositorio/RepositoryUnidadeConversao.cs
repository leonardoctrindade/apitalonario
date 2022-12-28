using Data.Config;
using Data.Entidades;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class RepositoryUnidadeConversao : RepositoryGenerics<UnidadeConversao>, IUnidadeConversao
    {
        public Task<List<UnidadeConversao>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}