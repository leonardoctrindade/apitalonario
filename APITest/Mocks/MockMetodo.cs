using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockMetodo
    {
        public static Metodo MontaObjetoUnico()
        {
            return new Metodo { Id = 1, Descricao = "Teste Mock 1", QuantidadeGotas = 1, Percentual = 12.3m };
        }

        public static Metodo MontaObjetoDescricaoVazia()
        {
            return new Metodo { Id = 1, Descricao = null, QuantidadeGotas = 3, Percentual = 15.25m };
        }

        public static List<Metodo> MontaListaItems()
        {
            return new List<Metodo>()
            {
                new Metodo() { Id = 1, Descricao = "Teste Mock 1", QuantidadeGotas = 1, Percentual = 1.1m },
                new Metodo() { Id = 2, Descricao = "Teste Mock 2", QuantidadeGotas = 2, Percentual = 1.2m },
                new Metodo() { Id = 3, Descricao = "Teste Mock 3", QuantidadeGotas = 3, Percentual = 1.3m },
            };
        }
    }
}
