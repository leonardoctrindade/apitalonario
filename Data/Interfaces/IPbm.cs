using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IPbm : IGeneric<Pbm>
    {
        Task<List<Pbm>> ListagemCustomizada();
    }
}
