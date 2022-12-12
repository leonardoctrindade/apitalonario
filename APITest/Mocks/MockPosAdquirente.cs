using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Mocks
{
    public static class MockPosAdquirente
    {
        public static PosAdquirente MontaObjetoUnico()
        {
            return new PosAdquirente { Id = 1, Descricao = "Teste 1", ChaveRequisicao = "Teste Mock 1" };
        }

        public static PosAdquirente MontaObjetoChaveRequisicaoVazia()
        {
            return new PosAdquirente { Id = 1, Descricao = "Teste 1", ChaveRequisicao = null };
        }

        public static List<PosAdquirente> MontaListaItems()
        {
            return new List<PosAdquirente>()
            {
                new PosAdquirente() { Id = 1, Descricao = "Teste Mock 1", ChaveRequisicao = "Teste Mock 1"},
                new PosAdquirente() { Id = 2, Descricao = "Teste Mock 2", ChaveRequisicao = "Teste Mock 2"},
                new PosAdquirente() { Id = 3, Descricao = "Teste Mock 3", ChaveRequisicao = "Teste Mock 3"}
            };
        }
    }
}
