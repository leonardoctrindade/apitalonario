using System;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IBula : IGeneric<Bula>
    {
        Task<List<Bula>> ListagemCustomizada(int pagina);
    }
}
