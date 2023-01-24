using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IPrescritor : IGeneric<Prescritor>
    {
        Task<List<Prescritor>> ListagemCustomizada(int pagina);
        Task<Prescritor> GetPrescritor(int id);
    }
}
