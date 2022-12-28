using System;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface INcm : IGeneric<Ncm>
    {
        Task<List<Ncm>> ListagemCustomizada();
        Task<Ncm> GetNcm(int id);
    }
}
