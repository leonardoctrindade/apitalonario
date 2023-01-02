using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockFormaFarmaceuticaEnsaio
    {
        public static FormaFarmaceuticaEnsaio MontaObjetoUnico()
        {
            return new FormaFarmaceuticaEnsaio { Id = 1, Descricao = "Teste Mock 1", FormaFarmaceuticaId = 1 };
        }

        public static FormaFarmaceuticaEnsaio MontaObjetoDescricaoVazia()
        {
            return new FormaFarmaceuticaEnsaio { Id = 1, Descricao = null, FormaFarmaceuticaId = 1 };
        }

        public static FormaFarmaceuticaEnsaio MontaObjetoFormaFarmaceuticaIdInvalido()
        {
            return new FormaFarmaceuticaEnsaio { Id = 1, Descricao = "Teste Mock 1", FormaFarmaceuticaId = 0 };
        }

        public static List<FormaFarmaceuticaEnsaio> MontaListaItems()
        {
            return new List<FormaFarmaceuticaEnsaio>()
            {
                new FormaFarmaceuticaEnsaio() { Id = 1, Descricao = "Teste Mock 1", FormaFarmaceuticaId = 1 },
                new FormaFarmaceuticaEnsaio() { Id = 2, Descricao = "Teste Mock 2", FormaFarmaceuticaId = 2 },
                new FormaFarmaceuticaEnsaio() { Id = 3, Descricao = "Teste Mock 3", FormaFarmaceuticaId = 3 }
            };
        }
    }
}
