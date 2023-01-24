using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IDcb : IGeneric<Dcb>
    {
        Task<List<Dcb>> ListagemCustomizada(int pagina);
    }
}
