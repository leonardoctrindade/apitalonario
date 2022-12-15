﻿using Data.Entidades;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class RepositoryTipoJustificativa : RepositoryGenerics<TipoJustificativa>, ITipoJustificativa
    {
        public Task<List<TipoJustificativa>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
