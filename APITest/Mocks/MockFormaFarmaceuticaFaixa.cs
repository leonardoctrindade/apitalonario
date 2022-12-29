using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace APITest.Mocks
{
    public static class MockFormaFarmaceuticaFaixa
    {
        public static FormaFarmaceuticaFaixa MontaObjetoUnico()
        {
            return new FormaFarmaceuticaFaixa
            {
                Id = 1,
                QuantidadeInicial = 123,
                QuantidadeFinal = 132,
                ValorMinimo = 312,
                SiglaUnidadeFaixa ="AA",
                FormaFarmaceuticaId = 1
            };
        }

        public static FormaFarmaceuticaFaixa MontaObjetoFormaFarmaceuticaIdVazio()
        {
            return new FormaFarmaceuticaFaixa
            {
                Id = 1,
                QuantidadeInicial = 123,
                QuantidadeFinal = 132,
                ValorMinimo = 312,
                SiglaUnidadeFaixa = "AA",
                FormaFarmaceuticaId = 0
            };
        }

        public static List<FormaFarmaceuticaFaixa> MontaListaItems()
        {
            return new List<FormaFarmaceuticaFaixa>()
            {
                new FormaFarmaceuticaFaixa()
                {
                    Id = 1,
                    QuantidadeInicial = 123,
                    QuantidadeFinal = 132,
                    ValorMinimo = 312,
                    SiglaUnidadeFaixa ="AA",
                    FormaFarmaceuticaId = 1
                },
                new FormaFarmaceuticaFaixa()
                {
                    Id = 2,
                    QuantidadeInicial = 123,
                    QuantidadeFinal = 132,
                    ValorMinimo = 312,
                    SiglaUnidadeFaixa ="AA",
                    FormaFarmaceuticaId = 2
                },
                new FormaFarmaceuticaFaixa()
                {
                    Id = 3,
                    QuantidadeInicial = 123,
                    QuantidadeFinal = 132,
                    ValorMinimo = 312,
                    SiglaUnidadeFaixa ="AA",
                    FormaFarmaceuticaId = 3
                }
            };
        }
    }
}
