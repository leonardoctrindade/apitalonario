using System;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface ITurno : IGeneric<Turno>
    {
        Task<List<Turno>> ListagemCustomizada(int pagina);
    }
}
