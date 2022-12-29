using System;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IFormaFarmaceutica : IGeneric<FormaFarmaceutica>
    {
        Task<List<FormaFarmaceutica>> ListagemCustomizada();
        Task<FormaFarmaceutica> GetFormaFarmaceutica(int id);
    }
}
