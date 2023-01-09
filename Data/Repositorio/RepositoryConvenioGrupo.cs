﻿using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Data.Config;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Data.Repositorio
{
    public class RepositoryConvenioGrupo: RepositoryGenerics<ConvenioGrupo>, IConvenioGrupo
    {
        public Task<List<ConvenioGrupo>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
