using System;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IDOM_RegimeTributario : IGeneric<DOM_RegimeTributario>
    {
        Task<DOM_RegimeTributario> RetornaRegimeTributarioPorID(int idRegimeTributarios);
    }
}
