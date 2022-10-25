using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IDOM_RegimeTributario : IGeneric<DOM_RegimeTributario>
    {
        Task<DOM_RegimeTributario> RetornaRegimeTributarioPorID(int idRegimeTributarios);
    }
}
