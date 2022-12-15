﻿using Data.Entidades;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class RepositoryEtapa : RepositoryGenerics<Etapa>, IEtapa
    {
        public Task<List<Etapa>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}