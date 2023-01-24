using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUnidade : IGeneric<Unidade>
    {
        Task<List<Unidade>> ListagemCustomizada(int pagina);
        Task<Unidade> GetUnidade(int id);
    }
}
