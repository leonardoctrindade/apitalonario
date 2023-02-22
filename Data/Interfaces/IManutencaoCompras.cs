using System;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IManutencaoCompras: IGeneric<ManutencaoCompras>
    {
        Task<List<ManutencaoCompras>> MontaFiltro(FiltroComprasManutencao filtroManutencaoCompras);
    }
}
