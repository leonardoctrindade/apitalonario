﻿using System;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface ITransacao : IGeneric<Transacao>
    {
        Task<List<Transacao>> ListagemCustomizada(int pagina);
        Task<Transacao> GetTransacao(int id);
    }
}
