﻿using Data.Entidades;
using Data.Interfaces;
using System;
using System.Collections.Generic;
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