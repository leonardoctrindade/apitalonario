using System;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IEntregadorRegiao : IGeneric<EntregadorRegiao>
    {
        Task<List<EntregadorRegiao>> ListagemCustomizada(int pagina);
        Task<EntregadorRegiao> GetEntregadorRegiao(int id);
    }
}
