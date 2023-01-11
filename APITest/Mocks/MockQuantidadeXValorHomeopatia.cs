using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockQuantidadeXValorHomeopatia
    {
        public static QuantidadeXValorHomeopatia MontaObjetoUnico()
        {
            return new QuantidadeXValorHomeopatia { Id = 1, QuantidadeInicial = 1, QuantidadeFinal = 2, ValorVenda = 123, ValorAdicional = 123, IntervaloDinamizacaoId = 1 };
        }

        public static QuantidadeXValorHomeopatia MontaObjetoQuantidadeInicialInvalida()
        {
            return new QuantidadeXValorHomeopatia { Id = 1, QuantidadeInicial = -1, QuantidadeFinal = 2, ValorVenda = 123, ValorAdicional = 123, IntervaloDinamizacaoId = 1 };
        }

        public static QuantidadeXValorHomeopatia MontaObjetoQuantidadeFinalInvalida()
        {
            return new QuantidadeXValorHomeopatia { Id = 1, QuantidadeInicial = 1, QuantidadeFinal = 0, ValorVenda = 123, ValorAdicional = 123, IntervaloDinamizacaoId = 1 };
        }
        
        public static QuantidadeXValorHomeopatia MontaObjetoValorVendaInvalida()
        {
            return new QuantidadeXValorHomeopatia { Id = 1, QuantidadeInicial = 1, QuantidadeFinal = 2, ValorVenda = 0, ValorAdicional = 123, IntervaloDinamizacaoId = 1 };
        }

        public static QuantidadeXValorHomeopatia MontaObjetoValorAdicionalInvalido()
        {
            return new QuantidadeXValorHomeopatia { Id = 1, QuantidadeInicial = 1, QuantidadeFinal = 2, ValorVenda = 123, ValorAdicional = -1, IntervaloDinamizacaoId = 1 };
        }

        public static QuantidadeXValorHomeopatia MontaObjetoIntervaloDinamizacaoIdInvalido()
        {
            return new QuantidadeXValorHomeopatia { Id = 1, QuantidadeInicial = 1, QuantidadeFinal = 2, ValorVenda = 123, ValorAdicional = 123, IntervaloDinamizacaoId = 0 };
        }

        public static QuantidadeXValorHomeopatia MontaObjetoQuantidadeFinalMenorQueQuantidadeInicial()
        {
            return new QuantidadeXValorHomeopatia { Id = 1, QuantidadeInicial = 3, QuantidadeFinal = 2, ValorVenda = 123, ValorAdicional = 123, IntervaloDinamizacaoId = 1 };
        }

        public static List<QuantidadeXValorHomeopatia> MontaListaItems()
        {
            return new List<QuantidadeXValorHomeopatia>()
            {
                new QuantidadeXValorHomeopatia { Id = 1, QuantidadeInicial = 1, QuantidadeFinal = 2, ValorVenda = 123, ValorAdicional = 123, IntervaloDinamizacaoId = 1 },
                new QuantidadeXValorHomeopatia { Id = 1, QuantidadeInicial = 2, QuantidadeFinal = 3, ValorVenda = 123, ValorAdicional = 123, IntervaloDinamizacaoId = 2 },
                new QuantidadeXValorHomeopatia { Id = 1, QuantidadeInicial = 3, QuantidadeFinal = 4, ValorVenda = 123, ValorAdicional = 123, IntervaloDinamizacaoId = 3 },
            };
        }
    }
}
