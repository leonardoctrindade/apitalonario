using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockIntervaloDinamizacaoHomeopatia
    {
        public static IntervaloDinamizacaoHomeopatia MontaObjetoUnico()
        {
            return new IntervaloDinamizacaoHomeopatia { Id = 1, Inicial = 1, Final = 2, TabelaHomeopatiaId = 1 };
        }

        public static IntervaloDinamizacaoHomeopatia MontaObjetoInicialInvalido()
        {
            return new IntervaloDinamizacaoHomeopatia { Id = 1, Inicial = 0, Final = 2, TabelaHomeopatiaId = 1 };
        }

        public static IntervaloDinamizacaoHomeopatia MontaObjetoFinalInvalido()
        {
            return new IntervaloDinamizacaoHomeopatia { Id = 1, Inicial = 1, Final = 0, TabelaHomeopatiaId = 1 };
        }

        public static IntervaloDinamizacaoHomeopatia MontaObjetoTabelaHomeopatiaIdInvalido()
        {
            return new IntervaloDinamizacaoHomeopatia { Id = 1, Inicial = 1, Final = 2, TabelaHomeopatiaId = 0 };
        }

        public static IntervaloDinamizacaoHomeopatia MontaObjetoFinalMenorQueInicial()
        {
            return new IntervaloDinamizacaoHomeopatia { Id = 1, Inicial = 3, Final = 2, TabelaHomeopatiaId = 1 };
        }

        public static List<IntervaloDinamizacaoHomeopatia> MontaListaItems()
        {
            return new List<IntervaloDinamizacaoHomeopatia>()
            {
                new IntervaloDinamizacaoHomeopatia() { Id = 1, Inicial = 1, Final = 2, TabelaHomeopatiaId = 1 },
                new IntervaloDinamizacaoHomeopatia() { Id = 2, Inicial = 2, Final = 3, TabelaHomeopatiaId = 2 },
                new IntervaloDinamizacaoHomeopatia() { Id = 3, Inicial = 3, Final = 4, TabelaHomeopatiaId = 3 }
            };
        }
    }
}
