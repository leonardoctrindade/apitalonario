using System;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IAdministradoraCartao : IGeneric<AdministradoraCartao> 
    {
        Task<List<AdministradoraCartao>> ListagemCustomizada();
        Task<AdministradoraCartao> PegarTudo(int id);
    }
}
