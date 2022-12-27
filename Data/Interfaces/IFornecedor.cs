﻿using System;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IFornecedor : IGeneric<Fornecedor>
    {
        Task<List<Fornecedor>> ListagemCustomizada();
        Task<Fornecedor> GetFornecedor(int id);
    }
}
