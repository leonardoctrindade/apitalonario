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
            return new NcmEstado { Id = 1, IdEstadoOrigem = 1, IdEstadoDestino = 2, IdTributoCst = 1, IdTributoCsosn = 1, AliquotaIcms = 12, AliquotaIcmsInterna = 1234, PercentualMva = 123, PercentualFcp = 123 , IdNcm = 1};
        }

        public static NcmEstado MontaObjetoIdEstadoOrigemInvalido()
        {
            return new NcmEstado { Id = 1, IdEstadoOrigem = 0, IdEstadoDestino = 2, IdTributoCst = 1, IdTributoCsosn = 1, AliquotaIcms = 12, AliquotaIcmsInterna = 1234, PercentualMva = 123, PercentualFcp = 123 , IdNcm = 1};
        }

        public static NcmEstado MontaObjetoIdEstadoDestinoInvalido()
        {
            return new NcmEstado { Id = 1, IdEstadoOrigem = 1, IdEstadoDestino =  0, IdTributoCst = 1, IdTributoCsosn = 1, AliquotaIcms = 12, AliquotaIcmsInterna = 1234, PercentualMva = 123, PercentualFcp = 123 , IdNcm = 1};
        }

        public static NcmEstado MontaObjetoIdNcmInvalido()
        {
            return new NcmEstado { Id = 1, IdEstadoOrigem = 1, IdEstadoDestino = 2, IdTributoCst = 1, IdTributoCsosn = 1, AliquotaIcms = 12, AliquotaIcmsInterna = 1234, PercentualMva = 123, PercentualFcp = 123, IdNcm = 0 };
        }

        public static List<NcmEstado> MontaListaItems()
        {
            return new List<NcmEstado>()
            {
                new NcmEstado() { Id = 1, IdEstadoOrigem = 1, IdEstadoDestino = 2, IdTributoCst = 1, IdTributoCsosn = 1, AliquotaIcms = 12, AliquotaIcmsInterna = 1234, PercentualMva = 123, PercentualFcp = 123, IdNcm = 1 },
                new NcmEstado() { Id = 2, IdEstadoOrigem = 2, IdEstadoDestino = 3, IdTributoCst = 2, IdTributoCsosn = 2, AliquotaIcms = 12, AliquotaIcmsInterna = 1234, PercentualMva = 123, PercentualFcp = 123, IdNcm = 2 },
                new NcmEstado() { Id = 3, IdEstadoOrigem = 3, IdEstadoDestino = 4, IdTributoCst = 3, IdTributoCsosn = 3, AliquotaIcms = 12, AliquotaIcmsInterna = 1234, PercentualMva = 123, PercentualFcp = 123, IdNcm = 3 }
            };
        }
    }
}
