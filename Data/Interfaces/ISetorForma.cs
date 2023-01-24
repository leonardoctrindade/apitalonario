﻿using System;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface ISetorForma : IGeneric<SetorForma>
    {
        Task<List<SetorForma>> ListagemCustomizada(int pagina);
    }
}
