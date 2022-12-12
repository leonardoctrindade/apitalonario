using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockEspecificacaoCapsula
    {
        public static EspecificacaoCapsula MontaObjetoUnico()
        {
            return new EspecificacaoCapsula { Id = 1, Descricao = "Teste Mock 1", Prioridade = 1 };
        }
        public static EspecificacaoCapsula MontaObjetoDescricaoVazia()
        {
            return new EspecificacaoCapsula { Id = 1, Descricao = null, Prioridade = 1 };
        }

        public static List<EspecificacaoCapsula> MontaListaItems()
        {
            return new List<EspecificacaoCapsula>()
            {
                new EspecificacaoCapsula() {Id = 1, Descricao = "Teste Mock 1", Prioridade = 1},
                new EspecificacaoCapsula() {Id = 2, Descricao = "Teste Mock 2", Prioridade = 2},
                new EspecificacaoCapsula() {Id = 3, Descricao = "Teste Mock 3", Prioridade = 3}
            };
        }
    }
}
