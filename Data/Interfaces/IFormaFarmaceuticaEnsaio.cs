﻿using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IFormaFarmaceuticaEnsaio : IGeneric<FormaFarmaceuticaEnsaio>
    {
        Task<List<FormaFarmaceuticaEnsaio>> ListagemCustomizada();
    }
}