using System;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IPbm : IGeneric<Pbm>
    {
        Task<List<Pbm>> ListagemCustomizada(int pagina);
    }
}
