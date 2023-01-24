using System;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IPais : IGeneric<Pais>
    {
        Task<List<Pais>> ListagemCustomizada(int pagina);
    }
}
