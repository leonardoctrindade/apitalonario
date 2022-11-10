using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockFarmacopeia
    {
        public static Farmacopeia MontaObjetoUnico()
        {
            return new Farmacopeia { Id = 1, Nome = "Teste Mock 1", Observacao = "Observação Mock"};
        }

        public static Farmacopeia MontaObjetoNomeVazio()
        {
            return new Farmacopeia { Id = 1, Nome = null, Observacao = "Observação Mock" };
        }

        public static List<Farmacopeia> MontaListaItems()
        {
            return new List<Farmacopeia>()
            {
                new Farmacopeia(){Id=1, Nome = "Teste Mock 1", Observacao = "Observação Mock 1"},
                new Farmacopeia(){Id=2, Nome = "Teste Mock 2", Observacao = "Observação Mock 2"},
                new Farmacopeia(){Id=3, Nome = "Teste Mock 3", Observacao = "Observação Mock 3"}
            };
        }
    }
}
