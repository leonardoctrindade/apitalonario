using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockNcmEstado
    {
        public static NcmEstado MontaObjetoUnico()
        {
            return new NcmEstado { Id = 1, EstadoOrigemId = 1, EstadoDestinoId = 2, TributoCstId = 1, TributoCsosnId = 1, AliquotaIcms = 12, AliquotaIcmsInterna = 1234, PercentualMva = 123, PercentualFcp = 123 , NcmId = 1};
        }

        public static NcmEstado MontaObjetoIdEstadoOrigemInvalido()
        {
            return new NcmEstado { Id = 1, EstadoOrigemId = 0, EstadoDestinoId = 2, TributoCstId = 1, TributoCsosnId = 1, AliquotaIcms = 12, AliquotaIcmsInterna = 1234, PercentualMva = 123, PercentualFcp = 123 , NcmId = 1};
        }

        public static NcmEstado MontaObjetoIdEstadoDestinoInvalido()
        {
            return new NcmEstado { Id = 1, EstadoOrigemId = 1, EstadoDestinoId =  0, TributoCstId = 1, TributoCsosnId = 1, AliquotaIcms = 12, AliquotaIcmsInterna = 1234, PercentualMva = 123, PercentualFcp = 123 , NcmId = 1};
        }

        public static NcmEstado MontaObjetoIdNcmInvalido()
        {
            return new NcmEstado { Id = 1, EstadoOrigemId = 1, EstadoDestinoId = 2, TributoCstId = 1, TributoCsosnId = 1, AliquotaIcms = 12, AliquotaIcmsInterna = 1234, PercentualMva = 123, PercentualFcp = 123, NcmId = 0 };
        }

        public static List<NcmEstado> MontaListaItems()
        {
            return new List<NcmEstado>()
            {
                new NcmEstado() { Id = 1, EstadoOrigemId = 1, EstadoDestinoId = 2, TributoCstId = 1, TributoCsosnId = 1, AliquotaIcms = 12, AliquotaIcmsInterna = 1234, PercentualMva = 123, PercentualFcp = 123, NcmId = 1 },
                new NcmEstado() { Id = 2, EstadoOrigemId = 2, EstadoDestinoId = 3, TributoCstId = 2, TributoCsosnId = 2, AliquotaIcms = 12, AliquotaIcmsInterna = 1234, PercentualMva = 123, PercentualFcp = 123, NcmId = 2 },
                new NcmEstado() { Id = 3, EstadoOrigemId = 3, EstadoDestinoId = 4, TributoCstId = 3, TributoCsosnId = 3, AliquotaIcms = 12, AliquotaIcmsInterna = 1234, PercentualMva = 123, PercentualFcp = 123, NcmId = 3 }
            };
        }
    }
}
