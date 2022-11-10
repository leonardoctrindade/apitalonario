using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockCidade
    {
        public static Cidade MontaObjetoUnico()
        {
            return new Cidade { Id = 1, Nome = "Teste Mock 1", CodigoIbge = 123, IdCodigoCfps = 123, CodigoSiafi = 123 };
        }

        public static Cidade MontaObjetoNomeVazio()
        {
            return new Cidade { Id = 1, Nome = null, CodigoIbge = 123, IdCodigoCfps = 123, CodigoSiafi = 123 };
        }

        public static List<Cidade> MontaListaItems()
        {
            return new List<Cidade>()
            {
                new Cidade(){Id = 1, Nome = "Teste Mock 1", CodigoIbge = 123, IdCodigoCfps = 123, CodigoSiafi = 123},
                new Cidade(){Id = 2, Nome = "Teste Mock 2", CodigoIbge = 123, IdCodigoCfps = 123, CodigoSiafi = 123},
                new Cidade(){Id = 3, Nome = "Teste Mock 3", CodigoIbge = 123, IdCodigoCfps = 123, CodigoSiafi = 123}
            };
        }
    }
}
