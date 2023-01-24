using System;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IVendedorComissao : IGeneric<VendedorComissao>
    {
        Task<List<VendedorComissao>> ListagemCustomizada(int pagina);
        Task<VendedorComissao> GetVendedorComissao(int id);
    }
}
