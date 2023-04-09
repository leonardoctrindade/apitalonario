using System;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IMultas : IGeneric<Multas>
    {
        Task<List<Multas>> ListagemCustomizada(int pagina);
        Task<Multas> BuscarMulta(int matricula, string placa, DateTime data, string hora, string infracao);
    }
}
