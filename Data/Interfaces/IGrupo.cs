using System;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IGrupo : IGeneric<Grupo>
    {
        Task<List<Grupo>> ListagemCustomizada(int pagina);
        Task<Grupo> GetGrupo(int Id);
    }
}
