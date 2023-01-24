using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface INbm : IGeneric<Nbm>
    {
        Task<List<Nbm>> ListagemCustomizada(int pagina);
    }
}
