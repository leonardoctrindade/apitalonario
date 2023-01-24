using System;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IBalanca : IGeneric<Balanca>
    {
        Task<List<Balanca>> ListagemCustomizada(int pagina);
    }
}
