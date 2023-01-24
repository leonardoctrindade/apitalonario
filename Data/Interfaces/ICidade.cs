using System;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace Data.Interfaces
{
    public interface ICidade : IGeneric<Cidade>
    {
        Task<List<Cidade>> ListagemCustomizada(int pagina);
        Task<Cidade> GetCidade(int id);
    }
}
