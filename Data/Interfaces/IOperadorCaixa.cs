using System;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IOperadorCaixa : IGeneric<OperadorCaixa>
    {
        Task<List<OperadorCaixa>> ListagemCustomizada(int pagina);
    }
}
