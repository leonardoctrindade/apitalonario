using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockPosologia
    {
        public static Posologia MontaObjetoUnico()
        {
            return new Posologia { Id = 1, Descricao = "Teste Mock 1", QuantidadeCapsulasOuDoses = 10, Periodo = 1 };
        }

        public static Posologia MontaObjetoDescricaoVazia()
        {
            return new Posologia { Id = 1, Descricao = null, QuantidadeCapsulasOuDoses = 10, Periodo = 1 };
        }

        public static List<Posologia> MontaListaItems()
        {
            return new List<Posologia>()
            {
                new Posologia() { Id = 1, Descricao = "Teste Mock 1", QuantidadeCapsulasOuDoses = 10, Periodo = 1 },
                new Posologia() { Id = 2, Descricao = "Teste Mock 2", QuantidadeCapsulasOuDoses = 5, Periodo = 0 },
                new Posologia() { Id = 3, Descricao = "Teste Mock 3", QuantidadeCapsulasOuDoses = 100, Periodo = 2 }
            };
        }
    }
}
