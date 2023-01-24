using System;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IConvenio : IGeneric<Convenio>
    {
        Task<List<Convenio>> ListagemCustomizada(int pagina);
        Task<Convenio> GetConvenio(int id);
    }
}

