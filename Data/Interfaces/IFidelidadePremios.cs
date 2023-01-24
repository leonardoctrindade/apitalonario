using System;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IFidelidadePremios : IGeneric<FidelidadePremios>
    {
        Task<List<FidelidadePremios>> ListagemCustomizada(int pagina);
        Task<FidelidadePremios> GetFidelidadePremios(int id);
    }
}
