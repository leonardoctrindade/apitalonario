using System;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IRegiao : IGeneric<Regiao>
    {
        Task<List<Regiao>> ListagemCustomizada();
    }
}
