using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockListaControlado
    {
        public static ListaControlado MontaObjetoUnico()
        {
            return new ListaControlado { Id = 1, Codigo = "Teste 1", Descricao = "Teste Mock 1", Tipo = 1, ReceitaObrigatorio = true };
        }

        public static ListaControlado MontaObjetoCodigoVazio()
        {
            return new ListaControlado { Id = 1, Codigo = null, Descricao = "Teste Mock 1", Tipo = 1, ReceitaObrigatorio = true };
        }

        public static ListaControlado MontaObjetoDescricaoVazia()
        {
            return new ListaControlado { Id = 1, Codigo = "Teste 1", Descricao = null, Tipo = 1, ReceitaObrigatorio = true };
        }

        public static List<ListaControlado> MontaListaItems()
        {
            return new List<ListaControlado>()
            {
                new ListaControlado() { Id = 1, Codigo = "Teste 1", Descricao = "Teste Mock 1", Tipo = 1, ReceitaObrigatorio = true },
                new ListaControlado() { Id = 2, Codigo = "Teste 2", Descricao = "Teste Mock 2", Tipo = 2, ReceitaObrigatorio = false },
                new ListaControlado() { Id = 3, Codigo = "Teste 3", Descricao = "Teste Mock 3", Tipo = 3, ReceitaObrigatorio = true }
            };
        }
    }
}
