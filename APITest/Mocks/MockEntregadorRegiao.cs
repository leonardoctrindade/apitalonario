using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockEntregadorRegiao
    {
        public static EntregadorRegiao MontaObjetoUnico()
        {
            return new EntregadorRegiao { Id = 1, EntregadorId = 1, RegiaoId = 1 };
        }

        public static EntregadorRegiao MontaObjetoIdEntregadorInvalido()
        {
            return new EntregadorRegiao { Id = 1, EntregadorId = 0, RegiaoId = 1 };
        }

        public static EntregadorRegiao MontaObjetoIdRegiaoInvalido()
        {
            return new EntregadorRegiao { Id = 1, EntregadorId = 1, RegiaoId = 0 };
        }

        public static List<EntregadorRegiao> MontaListaItems()
        {
            return new List<EntregadorRegiao>()
            {
                new EntregadorRegiao() { Id = 1, EntregadorId = 1, RegiaoId = 1 },
                new EntregadorRegiao() { Id = 2, EntregadorId = 2, RegiaoId = 2 },
                new EntregadorRegiao() { Id = 3, EntregadorId = 3, RegiaoId = 3 }
            };
        }
    }
}
