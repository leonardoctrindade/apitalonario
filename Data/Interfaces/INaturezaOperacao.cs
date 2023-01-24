using System;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace Data.Interfaces
{
    public interface INaturezaOperacao: IGeneric<NaturezaOperacao>
    {
        Task<List<NaturezaOperacao>> ListagemCustomizada(int pagina);
        Task<NaturezaOperacao> GetNaturezaOperacao(int id);
    }
}
