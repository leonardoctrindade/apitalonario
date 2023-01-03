using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockSetorForma
    {
        public static SetorForma MontaObjetoUnico()
        {
            return new SetorForma { Id = 1, SetorId = 1, FormaId = 1 };
        }

        public static SetorForma MontaObjetoSetorIdInvalido()
        {
            return new SetorForma { Id = 1, SetorId = 0, FormaId = 1 };
        }

        public static List<SetorForma> MontaListaItems()
        {
            return new List<SetorForma>()
            {
                new SetorForma() { Id = 1, SetorId = 1, FormaId = 1 },
                new SetorForma() { Id = 2, SetorId = 2, FormaId = 2 },
                new SetorForma() { Id = 3, SetorId = 3, FormaId = 3 },
            };
        }
    }
}
