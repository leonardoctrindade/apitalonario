using System;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IFornecedor : IGeneric<Fornecedor>
    {
        Task<List<Fornecedor>> ListagemCustomizada(int pagina);
        Task<Fornecedor> GetFornecedor(int id);
    }
}
