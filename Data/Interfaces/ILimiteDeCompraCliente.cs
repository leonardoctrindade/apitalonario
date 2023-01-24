using System;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface ILimiteDeCompraCliente : IGeneric<LimiteDeCompraCliente>
    {
        Task<List<LimiteDeCompraCliente>> ListagemCustomizada(int pagina);
    }
}
