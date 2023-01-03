using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockSetor
    {
        public static Setor MontaObjetoUnico()
        {
            return new Setor { Id = 1, Nome = "Teste Mock 1", IntervaloProducaoEntrega = DateTime.Now };
        }

        public static List<Setor> MontaListaItems()
        {
            return new List<Setor>()
            {
                new Setor() { Id = 1, Nome = "Teste Mock 1", IntervaloProducaoEntrega = DateTime.Now },
                new Setor() { Id = 2, Nome = "Teste Mock 2", IntervaloProducaoEntrega = DateTime.Now },
                new Setor() { Id = 3, Nome = "Teste Mock 3", IntervaloProducaoEntrega = DateTime.Now }
            };
        }
    }
}
