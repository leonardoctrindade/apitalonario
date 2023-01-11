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
            return new TabelaHomeopatia { Id = 1, Metodo = "Teste 1", FormaFarmaceuticaId = 1 };
        }

        public static TabelaHomeopatia MontaObjetoMetodoVazio()
        {
            return new TabelaHomeopatia { Id = 1, Metodo = null, FormaFarmaceuticaId = 1 };
        }

        public static List<TabelaHomeopatia> MontaListaItems()
        {
            return new List<TabelaHomeopatia>()
            {
                new TabelaHomeopatia() { Id = 1, Metodo = "Teste 1", FormaFarmaceuticaId = 1 },
                new TabelaHomeopatia() { Id = 2, Metodo = "Teste 2", FormaFarmaceuticaId = 2 },
                new TabelaHomeopatia() { Id = 3, Metodo = "Teste 3", FormaFarmaceuticaId = 3 }
            };
        }
    }
}
