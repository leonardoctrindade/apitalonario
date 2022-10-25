using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Mocks
{
    public static class MockPbm
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

        public static Pbm MontaObjetoUnico()
        {
            return new Pbm { Id = 1, Nome = "Teste Mock 1", Observacao = "Observação Mock" };
        }

        public static Pbm MontaObjetoNomeVazio()
        {
            return new Pbm { Id = 1, Nome = null, Observacao = "Observação Mock" };
        }

    }
}
