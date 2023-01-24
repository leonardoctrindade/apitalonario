using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IEtapa : IGeneric<Etapa>
    {
        Task<List<Etapa>> ListagemCustomizada(int pagina);
    }
}
