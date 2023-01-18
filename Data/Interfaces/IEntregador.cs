using System;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IEntregador : IGeneric<Entregador>
    {
        Task<List<Entregador>> ListagemCustomizada();
        Task<Entregador> GetEntregador(int id);
    }
}
