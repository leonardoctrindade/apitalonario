using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace APITest.Mocks
{
    public static class MockRestricaoDeUso
    {
        public static RestricaoDeUso MontaObjetoUnico()
        {
            return new RestricaoDeUso { Id = 1, ProdutoId = 1, GrupoId = 1, Observacao = "Teste Mock 1", ClienteId = 1 };
        }

        public static RestricaoDeUso MontaObjetoProdutoIdInvalido()
        {
            return new RestricaoDeUso { Id = 1, ProdutoId = 0, GrupoId = 1, Observacao = "Teste Mock 1", ClienteId = 1 };
        }

        public static RestricaoDeUso MontaObjetoGrupoIdInvalido()
        {
            return new RestricaoDeUso { Id = 1, ProdutoId = 1, GrupoId = 0, Observacao = "Teste Mock 1", ClienteId = 1 };
        }

        public static RestricaoDeUso MontaObjetoClienteIdInvalido()
        {
            return new RestricaoDeUso { Id = 1, ProdutoId = 1, GrupoId = 1, Observacao = "Teste Mock 1", ClienteId = 0 };
        }

        public static List<RestricaoDeUso> MontaListaItems()
        {
            return new List<RestricaoDeUso>()
            {
                new RestricaoDeUso() { Id = 1, ProdutoId = 1, GrupoId = 1, Observacao = "Teste Mock 1", ClienteId = 1 },
                new RestricaoDeUso() { Id = 2, ProdutoId = 2, GrupoId = 2, Observacao = "Teste Mock 2", ClienteId = 2 },
                new RestricaoDeUso() { Id = 3, ProdutoId = 3, GrupoId = 3, Observacao = "Teste Mock 3", ClienteId = 3 },
            };
        }
    }
}
