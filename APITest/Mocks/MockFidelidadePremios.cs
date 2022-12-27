using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockFidelidadePremios
    {
        public static FidelidadePremios MontaObjetoUnico()
        {
            return new FidelidadePremios { Id = 1, GrupoId = 1, ProdutoId = 1, Pontos = 0, FidelidadeId = 1 };
        }

        public static FidelidadePremios MontaObjetoIdGrupoInvalido()
        {
            return new FidelidadePremios { Id = 1, GrupoId = 0, ProdutoId = 1, Pontos = 0, FidelidadeId = 1 };
        }

        public static FidelidadePremios MontaObjetoIdProdutoInvalido()
        {
            return new FidelidadePremios { Id = 1, GrupoId = 1, ProdutoId = 0, Pontos = 0, FidelidadeId = 1 };
        }

        public static FidelidadePremios MontaObjetoPontosInvalido()
        {
            return new FidelidadePremios { Id = 1, GrupoId = 1, ProdutoId = 1, Pontos = -1, FidelidadeId = 1 };
        }

        public static FidelidadePremios MontaObjetoIdFidelidadeInvalido()
        {
            return new FidelidadePremios { Id = 1, GrupoId = 1, ProdutoId = 1, Pontos = 0, FidelidadeId = 0 };
        }

        public static List<FidelidadePremios> MontaListaItems()
        {
            return new List<FidelidadePremios>()
            {
                new FidelidadePremios() { Id = 1, GrupoId = 1, ProdutoId = 1, Pontos = 1, FidelidadeId = 1 },
                new FidelidadePremios() { Id = 2, GrupoId = 2, ProdutoId = 2, Pontos = 2, FidelidadeId = 2 },
                new FidelidadePremios() { Id = 3, GrupoId = 3, ProdutoId = 3, Pontos = 3, FidelidadeId = 3 }
            };
        }
    }
}
