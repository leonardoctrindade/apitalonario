using Data.Config;
using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IVisitador : IGeneric<Visitador>
    {
        Task<List<Visitador>> ListagemCustomizada(int pagina);
        Task<Visitador> GetVisitador(int id);
    }
}
