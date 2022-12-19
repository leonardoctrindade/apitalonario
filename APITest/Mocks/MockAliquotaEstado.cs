using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockAliquotaEstado
    {
        public static AliquotaEstado MontaObjetoUnico()
        {
            return new AliquotaEstado { Id = 1, IdEstadoDestino = 1, IdEstadoOrigem = 1, AliquotaIcms = 12 };
        }

        public static List<AliquotaEstado> MontaListaItems()
        {
            return new List<AliquotaEstado>()
            {
                new AliquotaEstado() { Id = 1, IdEstadoDestino = 1, IdEstadoOrigem = 1, AliquotaIcms = 10 },
                new AliquotaEstado() { Id = 2, IdEstadoDestino = 2, IdEstadoOrigem = 2, AliquotaIcms = 10 },
                new AliquotaEstado() { Id = 3, IdEstadoDestino = 3, IdEstadoOrigem = 3, AliquotaIcms = 10 }
            };
        }
    }
}
