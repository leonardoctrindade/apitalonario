using System;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IConfiguracoesPrismafive : IGeneric<ConfiguracoesPrismafive>
    {
        Task<List<ConfiguracoesPrismafive>> ListagemCustomizada(int pagina);
    }
}
