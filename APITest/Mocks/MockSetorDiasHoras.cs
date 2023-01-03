using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockSetorDiasHoras
    {
        public static SetorDiasHoras MontaObjetoUnico()
        {
            return new SetorDiasHoras { Id = 1, DiasHorasId = 1, SetorId = 1};
        }

        public static SetorDiasHoras MontaObjetoDiasHorasIdInvalido()
        {
            return new SetorDiasHoras { Id = 1, DiasHorasId = 0, SetorId = 1 };
        }

        public static SetorDiasHoras MontaObjetoSetorIdInvalido()
        {
            return new SetorDiasHoras { Id = 1, DiasHorasId = 1, SetorId = 0 };
        }

        public static List<SetorDiasHoras> MontaListaItems()
        {
            return new List<SetorDiasHoras>()
            {
                new SetorDiasHoras() { Id = 1, DiasHorasId = 1, SetorId = 1 },
                new SetorDiasHoras() { Id = 2, DiasHorasId = 2, SetorId = 2 },
                new SetorDiasHoras() { Id = 3, DiasHorasId = 3, SetorId = 3 }
            };
        }
    }
}
