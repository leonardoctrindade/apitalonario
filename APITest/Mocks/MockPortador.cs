using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockPortador
    {
        public static Portador MontaObjetoUnico()
        {
            return new Portador { Id = 1, Nome = "Teste 1", PortadorInativo = false };
        }

        public static Portador MontaObjetoNomeVazio()
        {
            return new Portador { Id = 1, Nome = null, PortadorInativo = true};
        }

        public static List<Portador> MontaListaItems()
        {
            return new List<Portador>()
            {
                new Portador() { Id = 1, Nome = "Teste Mock 1", PortadorInativo = true },
                new Portador() { Id = 2, Nome = "Teste Mock 2", PortadorInativo = false },
                new Portador() { Id = 3, Nome = "Teste Mock 3", PortadorInativo = true }
            };
        }
    }
}
