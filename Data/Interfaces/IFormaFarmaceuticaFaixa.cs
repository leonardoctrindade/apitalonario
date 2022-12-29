using System;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IFormaFarmaceuticaFaixa : IGeneric<FormaFarmaceuticaFaixa>
    {
        Task<List<FormaFarmaceuticaFaixa>> ListagemCustomizada();
        Task<FormaFarmaceuticaFaixa> GetFormaFarmaceuticaFaixa(int id);
    }
}
