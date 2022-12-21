using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockFidelidadeFormaPagamento
    {
        public static FidelidadeFormaPagamento MontaObjetoUnico()
        {
            return new FidelidadeFormaPagamento { Id = 1, CodigoFidelidade = 1, CodigoFormaPagamento = 1, Pontos = 0, Valor = 0 };
        }

        public static FidelidadeFormaPagamento MontaObjetoCodigoFidelidadeInvalido()
        {
            return new FidelidadeFormaPagamento { Id = 1, CodigoFidelidade = 0, CodigoFormaPagamento = 1, Pontos = 0, Valor = 0 };
        }

        public static FidelidadeFormaPagamento MontaObjetoCodigoFormaPagamentoInvalido()
        {
            return new FidelidadeFormaPagamento { Id = 1, CodigoFidelidade = 1, CodigoFormaPagamento = 0, Pontos = 0, Valor = 0 };
        }

        public static FidelidadeFormaPagamento MontaObjetoPontosInvalido()
        {
            return new FidelidadeFormaPagamento { Id = 1, CodigoFidelidade = 1, CodigoFormaPagamento = 1, Pontos = -2, Valor = 0 };
        }

        public static FidelidadeFormaPagamento MontaObjetoValorInvalido()
        {
            return new FidelidadeFormaPagamento { Id = 1, CodigoFidelidade = 1, CodigoFormaPagamento = 1, Pontos = 0, Valor = -2 };
        }

        public static List<FidelidadeFormaPagamento> MontaListaItems()
        {
            return new List<FidelidadeFormaPagamento>()
            {
                new FidelidadeFormaPagamento() { Id = 1, CodigoFidelidade = 1, CodigoFormaPagamento = 1, Pontos = 1, Valor = 1 },
                new FidelidadeFormaPagamento() { Id = 2, CodigoFidelidade = 2, CodigoFormaPagamento = 2, Pontos = 2, Valor = 2 },
                new FidelidadeFormaPagamento() { Id = 3, CodigoFidelidade = 3, CodigoFormaPagamento = 3, Pontos = 3, Valor = 3 }
            };
        }
    }
}
