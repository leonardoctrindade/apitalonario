﻿using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositorySetorForma: RepositoryGenerics<SetorForma>, ISetorForma
    {
        public Task<List<SetorForma>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
