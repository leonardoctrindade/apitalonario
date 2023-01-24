﻿using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IPosAdquirente : IGeneric<PosAdquirente>
    {
        Task<List<PosAdquirente>> ListagemCustomizada(int pagina);
    }
}
