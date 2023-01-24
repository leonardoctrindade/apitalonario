using System;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IHabitosCliente : IGeneric<HabitosCliente>
    {
        Task<List<HabitosCliente>> ListagemCustomizada(int pagina);
    }
}
