﻿using Data.Entidades;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class RepositoryDci : RepositoryGenerics<Dci>, IDci
    {
        public Task<List<Dci>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}