using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IMaquinaPos : IGeneric<MaquinaPos>
    {
        Task<List<MaquinaPos>> ListagemCustomizada(int paginaa);
        Task<MaquinaPos> GetMaquinaPos(int id);
    }
}
