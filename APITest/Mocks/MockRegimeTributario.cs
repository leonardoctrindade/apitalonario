using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Mocks
{
    public static class MockRegimeTributario
    {
        public static List<DOM_RegimeTributario> MontaListaItems()
        {
            return new List<DOM_RegimeTributario>()
            {
                new DOM_RegimeTributario(){Id=1, RegimeTributario="Simples Nacional"},
                new DOM_RegimeTributario(){Id=2, RegimeTributario="Simples Nacional Sublin"},
                new DOM_RegimeTributario(){Id=2, RegimeTributario="Regime Normal"}
            };

        }

        public static DOM_RegimeTributario MontaObjetoUnicoSimplesNacional()
        {
            return new DOM_RegimeTributario() { Id = 1, RegimeTributario = "Simples Nacional" };
        }

        public static DOM_RegimeTributario MontaObjetoUnico()
        {
            return new DOM_RegimeTributario() { Id = 1, RegimeTributario = "Simples Nacional" };
        }

        public static DOM_RegimeTributario MontaObjetoUnicoRegimeTributarioVazio()
        {
            return new DOM_RegimeTributario() { Id = 1, RegimeTributario = null };
        }

    }
}
