using System;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IEnsaio : IGeneric<Ensaio>
    {
        Task<List<Ensaio>> ListagemCustomizada();
        Task<Ensaio> GetEnsaio(int id);
    }
}
