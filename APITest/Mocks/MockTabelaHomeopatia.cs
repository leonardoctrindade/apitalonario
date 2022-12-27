using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace APITest.Mocks
{
    public static class MockTabelaHomeopatia
    {
        public static TabelaHomeopatia MontaObjetoUnico()
        {
            return new TabelaHomeopatia { Id = 1, Metodo = "Teste 1", FormaFarmaceuticaId = 1, DinamizacaoInicial = 1, DinamizacaoFinal = 30, Volume = 1, ValorAdicional = 10, ValorVenda = 10 };
        }

        public static TabelaHomeopatia MontaObjetoMetodoVazio()
        {
            return new TabelaHomeopatia { Id = 1, Metodo = null, FormaFarmaceuticaId = 1, DinamizacaoInicial = 1, DinamizacaoFinal = 30, Volume = 1, ValorAdicional = 10, ValorVenda = 10 };
        }

        public static TabelaHomeopatia MontaObjetoDinamizacaoInicialInvalida()
        {
            return new TabelaHomeopatia { Id = 1, Metodo = "Teste 1", FormaFarmaceuticaId = 1, DinamizacaoInicial = 0, DinamizacaoFinal = 30, Volume = 1, ValorAdicional = 10, ValorVenda = 10 };
        }

        public static TabelaHomeopatia MontaObjetoDinamizacaoFinalInvalida()
        {
            return new TabelaHomeopatia { Id = 1, Metodo = "Teste 1", FormaFarmaceuticaId = 1, DinamizacaoInicial = 1, DinamizacaoFinal = 0, Volume = 1, ValorAdicional = 10, ValorVenda = 10 };
        }

        public static TabelaHomeopatia MontaObjetoVolumeInvalida()
        {
            return new TabelaHomeopatia { Id = 1, Metodo = "Teste 1", FormaFarmaceuticaId = 1, DinamizacaoInicial = 1, DinamizacaoFinal = 30, Volume = -20, ValorAdicional = 10, ValorVenda = 10 };
        }

        public static List<TabelaHomeopatia> MontaListaItems()
        {
            return new List<TabelaHomeopatia>()
            {
                new TabelaHomeopatia() { Id = 1, Metodo = "Teste 1", FormaFarmaceuticaId = 1, DinamizacaoInicial = 1, DinamizacaoFinal = 30, Volume = 1, ValorAdicional = 10, ValorVenda = 10 },
                new TabelaHomeopatia() { Id = 2, Metodo = "Teste 2", FormaFarmaceuticaId = 2, DinamizacaoInicial = 1, DinamizacaoFinal = 30, Volume = 1, ValorAdicional = 10, ValorVenda = 10 },
                new TabelaHomeopatia() { Id = 3, Metodo = "Teste 3", FormaFarmaceuticaId = 3, DinamizacaoInicial = 1, DinamizacaoFinal = 30, Volume = 1, ValorAdicional = 10, ValorVenda = 10 }
            };
        }
    }
}
