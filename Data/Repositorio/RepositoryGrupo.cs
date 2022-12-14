﻿using Data.Entidades;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class RepositoryGrupo: RepositoryGenerics<Grupo>, IGrupo
    {
        public Task<List<Grupo>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
