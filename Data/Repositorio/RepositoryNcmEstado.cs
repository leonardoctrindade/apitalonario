﻿using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryNcmEstado: RepositoryGenerics<NcmEstado>, INcmEstado
    {
        public Task<List<NcmEstado>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
