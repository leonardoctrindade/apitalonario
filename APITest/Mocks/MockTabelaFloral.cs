using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockTabelaFloral
    {
        public static TabelaFloral MontaObjetoUnico()
        {
            return new TabelaFloral { Id = 1, Volume = 5, QuantidadeInicial = 1, QuantidadeFinal = 2, ValorVenda = 60 };
        }

        public static TabelaFloral MontaObjetoVolumeVazio()
        {
            return new TabelaFloral { Id = 1, Volume = 0, QuantidadeInicial = 1, QuantidadeFinal = 2, ValorVenda = 60 };
        }

        public static TabelaFloral MontaObjetoQuantidadeInicialVazio()
        {
            return new TabelaFloral { Id = 1, Volume = 5, QuantidadeInicial = 0, QuantidadeFinal = 2, ValorVenda = 60 };
        }

        public static TabelaFloral MontaObjetoQuantidadeFinalVazio()
        {
            return new TabelaFloral { Id = 1, Volume = 5, QuantidadeInicial = 1, QuantidadeFinal = 0, ValorVenda = 60 };
        }

        public static TabelaFloral MontaObjetoValorVendaVazio()
        {
            return new TabelaFloral { Id = 1, Volume = 5, QuantidadeInicial = 1, QuantidadeFinal = 2, ValorVenda = 0 };
        }

        public static List<TabelaFloral> MontaListaItems()
        {
            return new List<TabelaFloral>()
            {
                new TabelaFloral() { Id = 1, Volume = 5, QuantidadeInicial = 1, QuantidadeFinal = 2, ValorVenda = 60 },
                new TabelaFloral() { Id = 2, Volume = 5, QuantidadeInicial = 1, QuantidadeFinal = 2, ValorVenda = 60 },
                new TabelaFloral() { Id = 3, Volume = 5, QuantidadeInicial = 1, QuantidadeFinal = 2, ValorVenda = 60 }
            };
        }
    }
}
