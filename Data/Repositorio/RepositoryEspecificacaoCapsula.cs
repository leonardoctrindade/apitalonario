﻿using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryEspecificacaoCapsula: RepositoryGenerics<EspecificacaoCapsula>, IEspecificacaoCapsula
    {
        public Task<List<EspecificacaoCapsula>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}