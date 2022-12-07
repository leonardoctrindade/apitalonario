using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockTipoContato
    {
        public static TipoContato MontaObjetoUnico()
        {
            return new TipoContato { Id = 1, Descricao = "Teste Mock 1" };
        }

        public static TipoContato MontaObjetoDescricaoVazio()
        {
            return new TipoContato { Id = 1, Descricao = null };
        }

        public static List<TipoContato> MontaListaItems()
        {
            return new List<TipoContato>()
            {
                new TipoContato() {Id = 1, Descricao = "Teste Mock 1"},
                new TipoContato() {Id = 2, Descricao = "Teste Mock 2"},
                new TipoContato() {Id = 3, Descricao = "Teste Mock 3"}
            };
        }
    }
}
