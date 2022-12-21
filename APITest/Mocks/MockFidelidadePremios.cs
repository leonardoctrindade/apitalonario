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
            return new FidelidadePremios { Id = 1, IdGrupo = 1, IdProduto = 1, Pontos = 0, IdFidelidade = 1 };
        }

        public static FidelidadePremios MontaObjetoIdGrupoInvalido()
        {
            return new FidelidadePremios { Id = 1, IdGrupo = 0, IdProduto = 1, Pontos = 0, IdFidelidade = 1 };
        }

        public static FidelidadePremios MontaObjetoIdProdutoInvalido()
        {
            return new FidelidadePremios { Id = 1, IdGrupo = 1, IdProduto = 0, Pontos = 0, IdFidelidade = 1 };
        }

        public static FidelidadePremios MontaObjetoPontosInvalido()
        {
            return new FidelidadePremios { Id = 1, IdGrupo = 1, IdProduto = 1, Pontos = -1, IdFidelidade = 1 };
        }

        public static FidelidadePremios MontaObjetoIdFidelidadeInvalido()
        {
            return new FidelidadePremios { Id = 1, IdGrupo = 1, IdProduto = 1, Pontos = 0, IdFidelidade = 0 };
        }

        public static List<FidelidadePremios> MontaListaItems()
        {
            return new List<FidelidadePremios>()
            {
                new FidelidadePremios() { Id = 1, IdGrupo = 1, IdProduto = 1, Pontos = 1, IdFidelidade = 1 },
                new FidelidadePremios() { Id = 2, IdGrupo = 2, IdProduto = 2, Pontos = 2, IdFidelidade = 2 },
                new FidelidadePremios() { Id = 3, IdGrupo = 3, IdProduto = 3, Pontos = 3, IdFidelidade = 3 }
            };
        }
    }
}
