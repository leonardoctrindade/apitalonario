using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Mocks
{
    public static class MockDci
    {
        public static Dci MontaObjetoUnico()
        {
            return new Dci { Id = 1, CodigoDci = "123", Descricao = "Teste Mock 1"};
        }
        public static Dci MontaObjetoCodigoDciVazio()
        {
            return new Dci { Id = 1, CodigoDci = "", Descricao = "Teste Mock 1" }; 
        }
        public static Dci MontaObjetoDescricaoVazio()
        {
            return new Dci { Id = 1, CodigoDci = "123", Descricao = "" };
        }
        public static List<Dci> MontaListaItems()
        {
            return new List<Dci>()
            {
                new Dci(){Id = 1, CodigoDci = "123", Descricao = "Teste Mock 1"},
                new Dci(){Id = 2, CodigoDci = "1234", Descricao = "Teste Mock 2"},
                new Dci(){Id = 3, CodigoDci = "12345", Descricao = "Teste Mock 3"}
            };
        }
    }
}
