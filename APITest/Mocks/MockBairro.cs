using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockBairro
    {
        public static Bairro MontaObjetoUnico()
        {
            return new Bairro { Id = 1, Nome = "Teste Mock 1" };
        }

        public static Bairro MontaObjetoNomeVazio()
        {
            return new Bairro { Id = 1, Nome = null };
        }

        public static List<Bairro> MontaListaItems()
        {
            return new List<Bairro>()
            {
                new Bairro(){Id = 1, Nome = "Teste Mock 1"},
                new Bairro(){Id = 2, Nome = "Teste Mock 2"},
                new Bairro(){Id = 3, Nome = "Teste Mock 3"}
            };
        }
    }
}
