using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Mocks
{
    public static class MockFormaFarmaceuticaMargem
    {
        public static FormaFarmaceuticaMargem MontaObjetoUnico()
        {
            return new FormaFarmaceuticaMargem { Id = 1, ValorInicial = 1, ValorFinal = 1, Margem = 1, FormaFarmaceuticaId = 1 };
        }

        public static FormaFarmaceuticaMargem MontaObjetoFormaFarmaceuticaIdVazia()
        {
            return new FormaFarmaceuticaMargem { Id = 1, ValorInicial = 1, ValorFinal = 1, Margem = 1, FormaFarmaceuticaId = 0 };
        }

        public static List<FormaFarmaceuticaMargem> MontaListaItems()
        {
            return new List<FormaFarmaceuticaMargem>()
            {
                new FormaFarmaceuticaMargem() { Id = 1, ValorInicial = 1, ValorFinal = 1, Margem = 1, FormaFarmaceuticaId = 1 },
                new FormaFarmaceuticaMargem() { Id = 2, ValorInicial = 2, ValorFinal = 2, Margem = 2, FormaFarmaceuticaId = 2 },
                new FormaFarmaceuticaMargem() { Id = 3, ValorInicial = 3, ValorFinal = 3, Margem = 3, FormaFarmaceuticaId = 3 },
            };
        }
    }
}
