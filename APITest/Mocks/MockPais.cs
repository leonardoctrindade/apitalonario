using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace APITest.Mocks
{
    public static class MockPais
    {
        public static Pais MontaObjetoUnico()
        {
            return new Pais { Id = 1, Nome = "Teste Mock 1", CodigoIbge = 123, CodigoTelefonico = 123 };
        }

        public static Pais MontaObjetoNomeVazio()
        {
            return new Pais { Id = 1, Nome = null, CodigoIbge = 123, CodigoTelefonico = 123 };
        }

        public static List<Pais> MontaListaItems()
        {
            return new List<Pais>()
            {
                new Pais(){Id = 1, Nome = "Teste Mock 1", CodigoIbge = 123, CodigoTelefonico = 123},
                new Pais(){Id = 2, Nome = "Teste Mock 2", CodigoIbge = 123, CodigoTelefonico = 123},
                new Pais(){Id = 3, Nome = "Teste Mock 3", CodigoIbge = 123, CodigoTelefonico = 123}
            };
        }
    }
}
