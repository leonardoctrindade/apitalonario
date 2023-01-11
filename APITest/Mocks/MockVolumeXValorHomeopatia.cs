using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xunit.Sdk;

namespace APITest.Mocks
{
    public static class MockVolumeXValorHomeopatia
    {
        public static VolumeXValorHomeopatia MontaObjetoUnico()
        {
            return new VolumeXValorHomeopatia { Id = 1, Volume = 1, ValorVenda = 112, ValorAdicional = 1235, IntervaloDinamizacaoId = 1 };
        }

        public static VolumeXValorHomeopatia MontaObjetoVolumeInvalido()
        {
            return new VolumeXValorHomeopatia { Id = 1, Volume = 0, ValorVenda = 231, ValorAdicional = 123, IntervaloDinamizacaoId = 1 };
        }

        public static VolumeXValorHomeopatia MontaObjetoIntervaloDinanamizacaoIdInvalido()
        {
            return new VolumeXValorHomeopatia { Id = 1, Volume = 1, ValorVenda = 3124, ValorAdicional = 3241, IntervaloDinamizacaoId = 0 };
        }

        public static VolumeXValorHomeopatia MontaObjetoValorVendaInvalido()
        {
            return new VolumeXValorHomeopatia { Id = 1, Volume = 1, ValorVenda = 0, ValorAdicional = 3241, IntervaloDinamizacaoId = 1 };
        }

        public static VolumeXValorHomeopatia MontaObjetoValorAdicionalInvalido()
        {
            return new VolumeXValorHomeopatia { Id = 1, Volume = 1, ValorVenda = 161, ValorAdicional = 0, IntervaloDinamizacaoId = 1 };
        }

        public static List<VolumeXValorHomeopatia> MontaListaItems()
        {
            return new List<VolumeXValorHomeopatia>()
            {
                new VolumeXValorHomeopatia() { Id = 1, Volume = 1, ValorVenda = 1, ValorAdicional = 1, IntervaloDinamizacaoId = 1 },
                new VolumeXValorHomeopatia() { Id = 2, Volume = 2, ValorVenda = 2, ValorAdicional = 2, IntervaloDinamizacaoId = 2 },
                new VolumeXValorHomeopatia() { Id = 3, Volume = 3, ValorVenda = 3, ValorAdicional = 3, IntervaloDinamizacaoId = 3 }
            };
        }
    }
}
