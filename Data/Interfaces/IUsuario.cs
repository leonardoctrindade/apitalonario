﻿using System;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IUsuario : IGeneric<Usuario>
    {
        Task<List<Usuario>> ListagemCustomizada(int pagina);
        Task<Usuario> BuscarUsuario(int matricula, string senha);
    }
}
