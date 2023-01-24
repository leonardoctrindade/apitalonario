using System;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IEstado : IGeneric<Estado>
    {
        Task<List<Estado>> ListagemCustomizada(int pagina);
        Task<Estado> GetEstado(int id);
    }
}
