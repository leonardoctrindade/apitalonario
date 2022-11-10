﻿using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryBairro: RepositoryGenerics<Bairro>, IBairro
    {
        public Task<List<Bairro>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
