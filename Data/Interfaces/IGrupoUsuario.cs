﻿using System;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IGrupoUsuario : IGeneric<GrupoUsuario>
    {
        Task<List<GrupoUsuario>> ListagemCustomizada(int pagina);
    }
}
