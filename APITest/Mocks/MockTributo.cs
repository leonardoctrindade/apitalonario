using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockTributo
    {
        public static Tributo MontaObjetoUnico()
        {
            return new Tributo { Id = 1, Tipo = 1, Codigo = "Teste 1", Descricao = "Teste Mock 1" };
        }

        public static Tributo MontaObjetoTipoVazio()
        {
            return new Tributo { Id = 1, Codigo = "Teste 1", Descricao = "Teste Mock 1" };
        }

        public static Tributo MontaObjetoCodigoVazio()
        {
            return new Tributo { Id = 1, Tipo = 1, Descricao = "Teste Mock 1" };
        }

        public static Tributo MontaObjetoDescricaoVazio()
        {
            return new Tributo { Id = 1, Tipo = 1, Codigo = "Teste 1" };
        }

        public static List<Tributo> MontaListaItems()
        {
            return new List<Tributo>()
            {
                new Tributo(){Id = 1, Tipo = 1, Codigo = "Teste 1", Descricao = "Teste Mock 1"},
                new Tributo(){Id = 2, Tipo = 1, Codigo = "Teste 2", Descricao = "Teste Mock 2"},
                new Tributo(){Id = 3, Tipo = 1, Codigo = "Teste 3", Descricao = "Teste Mock 3"}
            };
        }
    }
}
