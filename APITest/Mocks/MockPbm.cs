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

        public static Pbm MontaObjetoUnico()
        {
            return new Pbm { Id = 1, Nome = "Teste Mock 1", Observacao = "Observação Mock" };
        }

        public static Pbm MontaObjetoNomeVazio()
        {
            return new Pbm { Id = 1, Nome = null, Observacao = "Observação Mock" };
        }


        public static List<Pbm> MontaListaItems()
        {
            return new List<Pbm>()
            {
                new Pbm(){Id=1, Nome = "Teste Mock 1", Observacao = "Observação Mock 1"},
                new Pbm(){Id=2, Nome = "Teste Mock 2", Observacao = "Observação Mock 2"},
                new Pbm(){Id=2, Nome = "Teste Mock 3", Observacao = "Observação Mock 3"}
            };

        }
    }
}
