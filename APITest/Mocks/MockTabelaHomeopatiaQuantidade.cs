using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Mocks
{
    public static class MockTabelaHomeopatiaQuantidade
    {
        public static TabelaHomeopatiaQuantidade MontaObjetoUnico()
        {
            return new TabelaHomeopatiaQuantidade
            {
                Id = 1,
                Metodo = "Teste 1",
                FormaFarmaceuticaId = 1,
                DinamizacaoInicial = 1,
                DinamizacaoFinal = 30,
                QuantidadeInicial = 1,
                QuantidadeFinal = 1,
                ValorVenda = 10,
                ValorAdicional = 10
            };
        }

        public static TabelaHomeopatiaQuantidade MontaObjetoMetodoVazio()
        {
            return new TabelaHomeopatiaQuantidade
            {
                Id = 1,
                Metodo = null,
                FormaFarmaceuticaId = 1,
                DinamizacaoInicial = 1,
                DinamizacaoFinal = 30,
                QuantidadeInicial = 1,
                QuantidadeFinal = 1,
                ValorVenda = 10,
                ValorAdicional = 10
            };
        }

        public static TabelaHomeopatiaQuantidade MontaObjetoDinamizacaoInicialInvalida()
        {
            return new TabelaHomeopatiaQuantidade
            {
                Id = 1,
                Metodo = "Teste",
                FormaFarmaceuticaId = 1,
                DinamizacaoInicial = 0,
                DinamizacaoFinal = 30,
                QuantidadeInicial = 1,
                QuantidadeFinal = 1,
                ValorVenda = 10,
                ValorAdicional = 10
            };
        }

        public static TabelaHomeopatiaQuantidade MontaObjetoDinamizacaoFinalInvalida()
        {
            return new TabelaHomeopatiaQuantidade
            {
                Id = 1,
                Metodo = "Teste",
                FormaFarmaceuticaId = 1,
                DinamizacaoInicial = 1,
                DinamizacaoFinal = 0,
                QuantidadeInicial = 1,
                QuantidadeFinal = 1,
                ValorVenda = 10,
                ValorAdicional = 10
            };
        }

        public static TabelaHomeopatiaQuantidade MontaObjetoQuantidadeInicialInvalida()
        {
            return new TabelaHomeopatiaQuantidade
            {
                Id = 1,
                Metodo = "Teste",
                FormaFarmaceuticaId = 1,
                DinamizacaoInicial = 1,
                DinamizacaoFinal = 30,
                QuantidadeInicial = -1,
                QuantidadeFinal = 1,
                ValorVenda = 10,
                ValorAdicional = 10
            };
        }

        public static TabelaHomeopatiaQuantidade MontaObjetoQuantidadeFinalInvalida()
        {
            return new TabelaHomeopatiaQuantidade
            {
                Id = 1,
                Metodo = "Teste",
                FormaFarmaceuticaId = 1,
                DinamizacaoInicial = 1,
                DinamizacaoFinal = 30,
                QuantidadeInicial = 1,
                QuantidadeFinal = 0,
                ValorVenda = 10,
                ValorAdicional = 10
            };
        }

        public static TabelaHomeopatiaQuantidade MontaObjetoValorVendaInvalido()
        {
            return new TabelaHomeopatiaQuantidade
            {
                Id = 1,
                Metodo = "Teste",
                FormaFarmaceuticaId = 1,
                DinamizacaoInicial = 1,
                DinamizacaoFinal = 30,
                QuantidadeInicial = 1,
                QuantidadeFinal = 1,
                ValorVenda = -1,
                ValorAdicional = 10
            };
        }

        public static TabelaHomeopatiaQuantidade MontaObjetoValorAdicionalInvalido()
        {
            return new TabelaHomeopatiaQuantidade
            {
                Id = 1,
                Metodo = "Teste",
                FormaFarmaceuticaId = 1,
                DinamizacaoInicial = 1,
                DinamizacaoFinal = 30,
                QuantidadeInicial = 1,
                QuantidadeFinal = 1,
                ValorVenda = 10,
                ValorAdicional = -1
            };
        }

        public static List<TabelaHomeopatiaQuantidade> MontaListaItems()
        {
            return new List<TabelaHomeopatiaQuantidade>()
            {
                new TabelaHomeopatiaQuantidade()
                {
                     Id = 1,
                    Metodo = "Teste 1",
                    FormaFarmaceuticaId = 1,
                    DinamizacaoInicial = 1,
                    DinamizacaoFinal = 30,
                    QuantidadeInicial = 1,
                    QuantidadeFinal = 1,
                    ValorVenda = 10,
                    ValorAdicional = 10
                },
                new TabelaHomeopatiaQuantidade()
                {
                     Id = 2,
                    Metodo = "Teste 2",
                    FormaFarmaceuticaId = 1,
                    DinamizacaoInicial = 1,
                    DinamizacaoFinal = 30,
                    QuantidadeInicial = 1,
                    QuantidadeFinal = 1,
                    ValorVenda = 10,
                    ValorAdicional = 10
                },
                 new TabelaHomeopatiaQuantidade()
                {
                     Id = 3,
                    Metodo = "Teste 3",
                    FormaFarmaceuticaId = 1,
                    DinamizacaoInicial = 1,
                    DinamizacaoFinal = 30,
                    QuantidadeInicial = 1,
                    QuantidadeFinal = 1,
                    ValorVenda = 10,
                    ValorAdicional = 10
                }
            };
        }
    }
}
