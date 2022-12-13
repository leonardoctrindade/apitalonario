using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace APITest.Mocks
{
    public static class MockBula
    {
        public static Bula MontaObjetoUnico()
        {
            return new Bula { Id = 1, Tipo = 1, LimitacaoVisual = false, Descricao = "Teste Mock 1" };
        }

        public static Bula MontaObjetoDescricaoVazia()
        {
            return new Bula { Id = 1, Tipo = 1, LimitacaoVisual = false, Descricao = null };
        }

        public static Bula MontaObjetoTipoIncorreto()
        {
            return new Bula { Id = 1, Tipo = 0, LimitacaoVisual = false, Descricao = "Teste Mock 1" };
        }

        public static List<Bula> MontaListaItems()
        {
            return new List<Bula>()
            {
                new Bula() { Id = 1, Tipo = 1, LimitacaoVisual = false, Descricao = "Teste Mock 1" },
                new Bula() { Id = 2, Tipo = 2, LimitacaoVisual = true, Descricao = "Teste Mock 2" },
                new Bula() { Id = 3, Tipo = 3, LimitacaoVisual = false, Descricao = "Teste Mock 3" }
            };
        }
    }
}
